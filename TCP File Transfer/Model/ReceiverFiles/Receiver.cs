using File_Transfer.Extensions;
using File_Transfer.LanguageManager;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Transfer.Model.ReceiverFiles
{
    public enum ReceiveResult
    {
        Completed,
        CannotReceived,
        Cancelled,
        FileIgnoredByUser,
        ListeningCancelled,
        ListeningFailed,
        RequestAccepted
    }

    public class Receiver : IReceiver
    {
        private const long RECEIVE_BUFFER = 2048;
        private const long INFO_BUFFER = 512;

        private long totalReceived = 0;
        private long fileSize = 0;

        private  TcpListener     TcpListener;
        private  NetworkStream   NetworkStream;
        private  Socket          Soket;

        private Stopwatch ElapsedTime = new Stopwatch();
        private System.Timers.Timer ProgressChangedInvoker = new System.Timers.Timer(500);

        private struct ReceivedFileInfo
        {
            public string FileName { get; set; }
            public long FileSize { get; set; }
        }

        private bool CancelFileReceiving { get; set; }
        private bool CancelListening { get; set; }

        public delegate void ProgressChanged(long current, long total, long totalTime);
        public delegate void ReceivingStarted();
        public delegate void ReceivingCompleted(ReceiveResult result, string message, string title);
        public delegate void ListenStartedEventHandler();
        public delegate void ListenCompleted(ReceiveResult result);

        public event ProgressChanged ProgressChangedEvent;
        public event ReceivingStarted ReceivingStartedEvent;
        public event ReceivingCompleted ReceivingCompletedEvent;
        public event ListenCompleted ListenCompletedEvent;
        public event ListenStartedEventHandler ListenStartedEvent;

        public IPAddress ReceiveIpAdress { get; set; }
        public int ReceivePortNumber { get; set; }
        public string ReceiveSaveLocation { get; set; }

        public bool IsFileReceiving { get; set; }
        public bool IsListening { get; set; }

        public Receiver()
        {
            Initialize();
        }

        private void Initialize()
        {
            IsListening = false;
            IsFileReceiving = false;
            CancelFileReceiving = false;
            CancelListening = false;

            ProgressChangedInvoker.Elapsed += ProgressChangedInvoker_Elapsed;
        }

        private void ProgressChangedInvoker_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (totalReceived > 0 && fileSize > 0 && IsFileReceiving)
                ProgressChangedEvent.Invoke(totalReceived, fileSize, ElapsedTime.ElapsedMilliseconds);
        }

        private void ReceivingFileStarted()
        {
            IsFileReceiving = true;
            ElapsedTime.Reset();
            ElapsedTime.Start();

            ProgressChangedInvoker.Enabled = true;

            ReceivingStartedEvent.Invoke();
        }

        private void ReceivingFileFinished(ReceiveResult result, string message, string title)
        {
            IsFileReceiving = false;

            ElapsedTime.Stop();

            ProgressChangedInvoker.Enabled = false;

            totalReceived = 0;
            fileSize = 0;

            IsListening = false;

            ReceivingCompletedEvent.Invoke(result, message, title);
        }

        private void ListenStarted()
        {
            IsListening = true;
            TcpListener = new TcpListener(ReceiveIpAdress, ReceivePortNumber);
            TcpListener.Start();

            ListenStartedEvent.Invoke();
        }

        private void ListenFinished(ReceiveResult result)
        {
            ListenCompletedEvent.Invoke(result);
        }

        public async void ListenForRequest()
        {
            try
            {
                ListenStarted();

                bool requestAccepted = false;
                await Task.Run(async () =>
              {
                  while (!CancelListening && !TcpListener.Pending()) ;

                  if (!CancelListening)
                  {
                      Soket = await TcpListener.AcceptSocketAsync();
                      NetworkStream = new NetworkStream(Soket);
                      requestAccepted = true;
                  }
              });
                if (requestAccepted)
                {
                    ListenFinished(ReceiveResult.RequestAccepted);
                    ReceiveFile();
                }
                else
                {
                    ListenFinished(ReceiveResult.ListeningCancelled);
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ListenFinished(ReceiveResult.ListeningFailed);
            }
        }

        private async void ReceiveFile()
        {
            try
            {
                ReceiveResult returnReceiveResult = ReceiveResult.CannotReceived;
                string returnMessage = string.Empty;
                string returnMessageTitle = string.Empty;

                byte[] fileInfoByte = new byte[INFO_BUFFER];
                
                await Task.Run(async () =>
                {
                    await NetworkStream.ReadAsync(fileInfoByte, 0, (int)INFO_BUFFER);
                });

                ReceivedFileInfo FileInfo = ReadFileInfoFromByte(fileInfoByte);
                fileSize = FileInfo.FileSize;

                string questionMessageBody = Translator.GetStringFromResource(MessageCodes.ReceiverAskForReceiveFile.ToString(), FileInfo.FileName, FileInfo.FileSize.formatSize());
                string questionMessageTitle = Translator.GetStringFromResource(MessageCodes.ReceiverAskForReceiveFileTitle.ToString());

                if (MessageBox.Show(questionMessageBody, questionMessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    returnReceiveResult = ReceiveResult.FileIgnoredByUser;
                    returnMessage = Translator.GetStringFromResource(MessageCodes.ReceiverFileRejectedByUser.ToString());
                    returnMessageTitle = Translator.GetStringFromResource(MessageCodes.ReceiverFileRejectedByUserTitle.ToString());

                    ReceivingFileFinished(returnReceiveResult, returnMessage, returnMessageTitle);

                    return;
                }

                using (FileStream fstream = new FileStream(ReceiveSaveLocation + @"\" + FileInfo.FileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    byte[]  buff            =    new byte[RECEIVE_BUFFER];
                    int     buffered        =    0;

                    ReceivingFileStarted();

                    await Task.Run(async () =>
                    {
                        if (!NetworkStream.CanRead)
                        {
                            returnReceiveResult = ReceiveResult.CannotReceived;
                            returnMessage = Translator.GetStringFromResource(MessageCodes.ReceiverCouldntReadStream.ToString());
                            returnMessageTitle = Translator.GetStringFromResource(MessageCodes.ReceiverCouldntReadStreamTitle.ToString());

                            return;
                        }
                        while ((buffered = await NetworkStream.ReadAsync(buff, 0, buff.Length)) > 0)
                        {
                            if (CancelFileReceiving)
                            {
                                returnReceiveResult = ReceiveResult.Cancelled;
                                returnMessage = Translator.GetStringFromResource(MessageCodes.ReceiverCancelledByUser.ToString());
                                returnMessageTitle = Translator.GetStringFromResource(MessageCodes.ReceiverCancelledByUserTitle.ToString());

                                return;
                            }
                            await fstream.WriteAsync(buff, 0, buffered);
                            totalReceived += buffered;
                        }

                        if (totalReceived < FileInfo.FileSize)
                        {
                            returnReceiveResult = ReceiveResult.CannotReceived;
                            returnMessage = Translator.GetStringFromResource(MessageCodes.ReceiverFailed.ToString());
                            returnMessageTitle = Translator.GetStringFromResource(MessageCodes.ReceiverFailedTitle.ToString());

                            return;
                        }
                        returnReceiveResult = ReceiveResult.Completed;
                        returnMessage = Translator.GetStringFromResource(MessageCodes.ReceiverCompleted.ToString());
                        returnMessageTitle = Translator.GetStringFromResource(MessageCodes.ReceiverCompletedTitle.ToString());
                    });
                    ReceivingFileFinished(returnReceiveResult, returnMessage, returnMessageTitle);
                }
            }
            catch (IOException ex)
            {
                var errcode = ex.InnerException as Win32Exception;
                
                if (errcode != null && errcode.ErrorCode == 10054)
                {
                    ReceivingFileFinished(ReceiveResult.CannotReceived, Translator.GetStringFromResource(MessageCodes.ReceiverIOException10054.ToString()), Translator.GetStringFromResource(MessageCodes.ReceiverIOException10054Title.ToString()));
                }
                else
                {
                    ReceivingFileFinished(ReceiveResult.CannotReceived, Translator.GetStringFromResource(MessageCodes.ReceiverIOException.ToString()), Translator.GetStringFromResource(MessageCodes.ReceiverIOExceptionTitle.ToString()));
                }
            }
            catch (Exception exception)
            {
                ReceivingFileFinished(ReceiveResult.CannotReceived, Translator.GetStringFromResource(MessageCodes.ReceiverException.ToString(), exception.Message), Translator.GetStringFromResource(MessageCodes.ReceiverExceptionTitle.ToString()));
            }
            finally
            {
                Dispose();
            }
        }

        private ReceivedFileInfo ReadFileInfoFromByte(byte[] fileInfoByte)
        {
            string fileInfoStr = Encoding.UTF8.GetString(fileInfoByte);
            int firstPaddingIndex = fileInfoStr.IndexOf('|');
            int lastPaddingIndex = fileInfoStr.LastIndexOf('|');

            long fileSize = long.Parse(fileInfoStr.Substring(0, firstPaddingIndex));
            string fileName = fileInfoStr.Substring(firstPaddingIndex + 1, (lastPaddingIndex - firstPaddingIndex) - 1);

            fileInfoStr = null;

            return new ReceivedFileInfo() { FileName = fileName, FileSize = fileSize };
        }

        public void CancelReceivingFile()
        {
            CancelFileReceiving = true;
        }

        public void CancelListeningFile()
        {
            CancelListening = true;
        }

        public void Dispose()
        {
            if (Soket != null)
            {
                Soket.Close();
                Soket.Dispose();
                Soket = null;
            }

            if (TcpListener != null)
            {
                TcpListener.Stop();
                TcpListener = null;
            }

            if (NetworkStream != null)
            {
                NetworkStream.Close();
                NetworkStream.Dispose();
                NetworkStream = null;
            }
            Initialize();
        }
    }
}
