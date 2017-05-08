using File_Transfer.Extensions;
using File_Transfer.LanguageManager;

using File_Transfer.Model;
using File_Transfer.View;
using System.Net;
using System.Windows.Forms;

namespace File_Transfer.Controller
{
    public class MainViewController
    {
        TransferFileEngine TransferEngine;
        MainView MainView;

        public MainViewController(MainView mainView, TransferFileEngine transferEngine)
        {
            Initialize(mainView, transferEngine);
        }

        private void Initialize(MainView mainView, TransferFileEngine transferEngine)
        {
            this.MainView = mainView;
            this.TransferEngine = transferEngine;

            MainView.SetController(this);

            TransferEngine.InitializeEventHandlers(MainView);
        }

        public void SendFileOrCancel()
        {
            if (!CheckAndSetOptionsForOperation(Operation.SendFile)) return;

            if (!TransferEngine.IsSending && !TransferEngine.IsWaitingForConnect) //Şuan da dosya gönderilmiyor ise dosya gönderme işlemine başla
            {
                TransferEngine.SendFile(); //Dosya gönderme işlemini başlat ve sonucu bekle
            }
            else if (!TransferEngine.IsWaitingForConnect) //Dosya gönderiliyor ise iptal et
            {
                TransferEngine.CancelSendingFile();
            }
            else //Henüz bağlantı kurulmaya çalışıyorsa
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
        public void ReceiveFileOrCancel()
        {
            if (!CheckAndSetOptionsForOperation(Operation.ReceiveFile)) return;

            if (!TransferEngine.IsListening && !TransferEngine.IsFileReceiving)
            {
                TransferEngine.ListenForRequest();
            }
            else if (TransferEngine.IsFileReceiving)
            {
                TransferEngine.CancelReceivingFile();
            }
            else if (TransferEngine.IsListening)
            {
                TransferEngine.CancelListeningFile();
            }
        }

        public enum Operation
        {
            SendFile,
            ReceiveFile
        }
        public bool CheckAndSetOptionsForOperation(Operation operationType)
        {
            if (operationType == Operation.SendFile)
            {
                if (!MainView.GetInputValueOnForm(MainFormInputs.FileNameForSend).IsValidFilePath())
                {
                    MessageBox.Show(MainView,  Translator.GetStringFromResource(MessageCodes.InvalidFilenameMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidFilenameMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (!MainView.GetInputValueOnForm(MainFormInputs.SendIPAdress).IsValidIpAdress())
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidIpAddressMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidIpAddressMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (!MainView.GetInputValueOnForm(MainFormInputs.SendPortNumber).IsValidPortNumber())
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidPortNumberMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidPortNumberMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                try
                {
                    TransferEngine.SendIpAdress = IPAddress.Parse(MainView.GetInputValueOnForm(MainFormInputs.SendIPAdress));
                    TransferEngine.SendPortNumber = int.Parse(MainView.GetInputValueOnForm(MainFormInputs.SendPortNumber));
                    TransferEngine.SendFileName = MainView.GetInputValueOnForm(MainFormInputs.FileNameForSend);
                }
                catch
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidFormInputMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidFormInputMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (!MainView.GetInputValueOnForm(MainFormInputs.SaveLocationForReceive).IsValidSavePath())
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidSaveLocationMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidSaveLocationMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (!MainView.GetInputValueOnForm(MainFormInputs.ReceiveIPAdress).IsValidIpAdress())
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidIpAddressMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidIpAddressMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (!MainView.GetInputValueOnForm(MainFormInputs.ReceivePortNumber).IsValidPortNumber())
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidPortNumberMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidPortNumberMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                try
                {
                    TransferEngine.ReceiveIpAdress = IPAddress.Parse(MainView.GetInputValueOnForm(MainFormInputs.ReceiveIPAdress));
                    TransferEngine.ReceivePortNumber = int.Parse(MainView.GetInputValueOnForm(MainFormInputs.ReceivePortNumber));
                    TransferEngine.ReceiveSaveLocation = MainView.GetInputValueOnForm(MainFormInputs.SaveLocationForReceive);
                }
                catch
                {
                    MessageBox.Show(MainView, Translator.GetStringFromResource(MessageCodes.InvalidFormInputMessage.ToString()), Translator.GetStringFromResource(MessageCodes.InvalidFormInputMessageTitle.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
                
            return true;
        }
    }
}
