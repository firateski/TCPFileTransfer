using File_Transfer.LanguageManager;

using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;

namespace File_Transfer.Model.SenderFiles
{
    public enum SendResult
    {
        Completed,
        CannotSend,
        Cancelled
    }

    public class Sender : ISender
    {
        private const long SEND_BUFFER = 2048;
        private const long INFO_BUFFER = 512;

        private long totalSent = 0;
        private byte[] byteToSend;

        private TcpClient TcpClient;
        private NetworkStream NetworkStream;

        private Stopwatch ElapsedTime = new Stopwatch();
        private Timer ProgressChangedInvoker = new Timer(500);

        public IPAddress SendIpAdress { get; set; }
        public int SendPortNumber { get; set; }
        public string SendFileName { get; set; }

        private bool IsConnected{ get; set; }
        private bool IsCancelled { get; set; }

        public delegate void ProgressChanged(long current, long total, long totalTime);
        public delegate void SendingCompleted(SendResult result, string message, string title);
        public delegate void SendingFileStartedEventHandler();

        public event ProgressChanged ProgressChangedEvent;
        public event SendingFileStartedEventHandler SendingFileStartedEvent;
        public event SendingCompleted SendingCompletedEvent;

        public bool IsWaitingForConnect { get; set; } = false;
        public bool IsSending { get; set; }

        public Sender()
        {
            Initialize();
        }

        private void Initialize()
        {
            IsConnected = false;
            IsCancelled = false;
            IsSending = false;
            IsWaitingForConnect = false;

            ProgressChangedInvoker.Elapsed += ProgressChangedInvoker_Elapsed;
        }

        private void ProgressChangedInvoker_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (totalSent > SEND_BUFFER * SEND_BUFFER && byteToSend != null && totalSent > 0)
                ProgressChangedEvent.Invoke(totalSent, byteToSend.Length, ElapsedTime.ElapsedMilliseconds);
        }

        private void SendingFileStarted()
        {
            IsSending = true;

            ElapsedTime.Reset();
            ElapsedTime.Start();

            ProgressChangedInvoker.Enabled = true;

            SendingFileStartedEvent.Invoke();
        }

        private void SendingFileFinished(SendResult result, string message, string title)
        {
            IsSending = false;
            ElapsedTime.Stop();

            ProgressChangedInvoker.Enabled = false;
            totalSent = 0;
            byteToSend = null;

            SendingCompletedEvent.Invoke(result, message, title);
        }

        private async Task<bool> Connect()
        {
            if (!IsConnected)
            {
                try
                {
                    IsWaitingForConnect = true;
                    await Task.Run(() =>
                   {
                       TcpClient = new TcpClient(SendIpAdress.ToString(), SendPortNumber);
                       NetworkStream = TcpClient.GetStream();
                   });

                    IsConnected = true;
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    IsWaitingForConnect = false;
                }
            }
            else
            {
                return true;
            }
        }

        private byte[] GetPacketToSend()
        {
            FileInfo file = new FileInfo(SendFileName);
            string fileInfoStr = file.Length.ToString() + "|" + file.Name + "|";
            byte[] fileInfoByte = Encoding.UTF8.GetBytes(fileInfoStr);

            if (fileInfoByte.Length < (int)INFO_BUFFER)
            {
                int requiredByte = (int)INFO_BUFFER - fileInfoByte.Length;

                for (int i = 0; i < requiredByte; i++)
                {
                    fileInfoStr += " ";
                }
                fileInfoByte = Encoding.UTF8.GetBytes(fileInfoStr);
            }

            byte[] byteToSend;
            byte[] fileByte = File.ReadAllBytes(SendFileName);
            byteToSend = new byte[fileByte.Length + fileInfoByte.Length];

            fileInfoByte.CopyTo(byteToSend, 0);
            fileByte.CopyTo(byteToSend, INFO_BUFFER);

            return byteToSend;
        }

        private bool Disconnect()
        {
            if (TcpClient != null)
            {
                TcpClient.Close();
            }

            if (NetworkStream != null)
            {
                try
                {
                    NetworkStream.Close();
                }
                catch
                {
                    NetworkStream = null;
                }
            }

            IsConnected = false;

            return true;
        }

        public bool CancelSendingFile()
        {
            if (IsSending)
            {
                IsCancelled = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void SendFile()
        {
            try
            {
                SendResult returnSendResult = SendResult.CannotSend;
                string returnMessage = string.Empty;
                string returnMessageTitle = string.Empty;

                if (!await Connect())
                {
                    returnSendResult = SendResult.CannotSend;
                    returnMessage = Translator.GetStringFromResource(MessageCodes.SenderConnectError.ToString());
                    returnMessageTitle = Translator.GetStringFromResource(MessageCodes.SenderConnectErrorTitle.ToString());

                    SendingFileFinished(returnSendResult, returnMessage, returnMessageTitle);
                    return;
                }

                byteToSend = GetPacketToSend();
                byte[] buff = new byte[SEND_BUFFER];

                long noOfPack = (byteToSend.Length % SEND_BUFFER == 0) ?
                    byteToSend.Length / SEND_BUFFER :
                    ((byteToSend.Length - (byteToSend.Length % SEND_BUFFER)) / SEND_BUFFER) + 1;

                SendingFileStarted();

                await Task.Run(async () =>
              {
                  if (NetworkStream != null)
                  {
                      int loopStep = 0;
                      while (noOfPack > 0)
                      {
                          if (!NetworkStream.CanWrite)
                          {
                              returnSendResult = SendResult.CannotSend;
                              returnMessage = Translator.GetStringFromResource(MessageCodes.SenderCouldntWriteToStream.ToString());
                              returnMessageTitle = Translator.GetStringFromResource(MessageCodes.SenderCouldntWriteToStreamTitle.ToString());

                              return;
                          }
                          if (IsCancelled)
                          {
                              returnSendResult = SendResult.Cancelled;
                              returnMessage = Translator.GetStringFromResource(MessageCodes.SenderCancelledByUser.ToString());
                              returnMessageTitle = Translator.GetStringFromResource(MessageCodes.SenderCancelledByUserTitle.ToString());

                              return;
                          }

                          if (noOfPack > 1) //Son paket değilse
                              Array.Copy(byteToSend, loopStep * SEND_BUFFER, buff, 0, SEND_BUFFER);
                          else //Son paket ise
                              Array.Copy(byteToSend, loopStep * SEND_BUFFER, buff, 0, byteToSend.Length % SEND_BUFFER);

                          await NetworkStream.WriteAsync(buff, 0, buff.Length);

                          totalSent += buff.Length;

                          --noOfPack;
                          ++loopStep;
                      }
                      returnSendResult = SendResult.Completed;
                      returnMessage = Translator.GetStringFromResource(MessageCodes.SenderCompleted.ToString());
                      returnMessageTitle = Translator.GetStringFromResource(MessageCodes.SenderCompletedTitle.ToString());

                      return;
                  }
                  else
                  {
                      returnSendResult = SendResult.CannotSend;
                      returnMessage = Translator.GetStringFromResource(MessageCodes.SenderException.ToString());
                      returnMessageTitle = Translator.GetStringFromResource(MessageCodes.SenderExceptionTitle.ToString());
                  }
              });
                SendingFileFinished(returnSendResult, returnMessage, returnMessageTitle);
            }
            catch (ArgumentNullException)
            {
                SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderArgumentNullException.ToString()), Translator.GetStringFromResource(MessageCodes.SenderArgumentNullExceptionTitle.ToString()));
            }
            catch (ArgumentException)
            {
                SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderArgumentException.ToString()), Translator.GetStringFromResource(MessageCodes.SenderArgumentExceptionTitle.ToString()));
            }
            catch (PathTooLongException)
            {
                SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderPathTooLongException.ToString()), Translator.GetStringFromResource(MessageCodes.SenderPathTooLongExceptionTitle.ToString()));
            }
            catch (DirectoryNotFoundException)
            {
                SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderDirectoryNotFoundException.ToString()), Translator.GetStringFromResource(MessageCodes.SenderDirectoryNotFoundExceptionTitle.ToString()));
            }
            catch (IOException ex)
            {
                var errcode = ex.InnerException as Win32Exception;

                if (errcode != null && errcode.ErrorCode == 10054)
                {
                    SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderIOExceptionError10054.ToString()), Translator.GetStringFromResource(MessageCodes.SenderIOExceptionError10054Title.ToString()));
                }
                else
                {
                    SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderIOException.ToString()), Translator.GetStringFromResource(MessageCodes.SenderIOExceptionTitle.ToString()));
                }
            }
            catch (UnauthorizedAccessException)
            {
                SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderUnauthorizedAccessException.ToString()), Translator.GetStringFromResource(MessageCodes.SenderUnauthorizedAccessExceptionTitle.ToString()));
            }
            catch (Exception exception)
            {
                SendingFileFinished(SendResult.CannotSend, Translator.GetStringFromResource(MessageCodes.SenderException.ToString(), exception.Message), Translator.GetStringFromResource(MessageCodes.SenderExceptionTitle.ToString()));
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Disconnect();
            Initialize();

            if (NetworkStream != null)
            {
                NetworkStream.Dispose();
                NetworkStream = null;
            }

            if(TcpClient != null)
            {
                TcpClient = null;
            }
        }
    }
}
