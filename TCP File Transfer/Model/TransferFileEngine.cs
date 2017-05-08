using File_Transfer.Model.ReceiverFiles;
using File_Transfer.Model.SenderFiles;

using System.Net;
using File_Transfer.View;

namespace File_Transfer.Model
{
    public class TransferFileEngine : ISender, IReceiver
    {
        private Sender Sender;
        private Receiver Receiver;

        public TransferFileEngine()
        {
            Sender = new Sender();
            Receiver = new Receiver();
        }

        public void InitializeEventHandlers(MainView view)
        {
            //Sender Event Handlers
            Sender.ProgressChangedEvent       +=  view.FileSender_ProgressChangedEvent;
            Sender.SendingCompletedEvent      +=  view.FileSender_sendingCompletedEvent;
            Sender.SendingFileStartedEvent    +=  view.FileSender_SendingFileStartedEvent;

            //Receiver Event Handlers
            Receiver.ProgressChangedEvent     +=  view.FileReceiver_ProgressChangedEvent;
            Receiver.ReceivingStartedEvent    +=  view.FileReceiver_ReceivingStartedEvent;
            Receiver.ReceivingCompletedEvent  +=  view.FileReceiver_ReceivingCompletedEvent;
            Receiver.ListenCompletedEvent     +=  view.FileReceiver_ListenCompletedEvent;
            Receiver.ListenStartedEvent       +=  view.FileReceiver_ListenStartedEvent;
        }

        public IPAddress SendIpAdress
        {
            get
            {
                return Sender.SendIpAdress;
            }
            set
            {
                Sender.SendIpAdress = value;
            }
        }

        public IPAddress ReceiveIpAdress
        {
            get
            {
                return Receiver.ReceiveIpAdress;
            }
            set
            {
                Receiver.ReceiveIpAdress = value;
            }
        }

        public int SendPortNumber
        {
            get
            {
                return Sender.SendPortNumber;
            }
            set
            {
                Sender.SendPortNumber = value;
            }
        }

        public int ReceivePortNumber
        {
            get
            {
                return Receiver.ReceivePortNumber;
            }
            set
            {
                Receiver.ReceivePortNumber = value;
            }
        }

        public string SendFileName
        {
            get
            {
                return Sender.SendFileName;
            }
            set
            {
                Sender.SendFileName = value;
            }
        }

        public string ReceiveSaveLocation
        {
            get
            {
                return Receiver.ReceiveSaveLocation;
            }
            set
            {
                Receiver.ReceiveSaveLocation = value;
            }
        }

        public bool IsWaitingForConnect
        {
            get
            {
                return Sender.IsWaitingForConnect;
            }
            set
            {
                Sender.IsWaitingForConnect = value;
            }
        }
        public bool IsSending
        {
            get
            {
                return Sender.IsSending;
            }
            set
            {
                Sender.IsSending = value;
            }
        }

        public bool IsFileReceiving
        {
            get
            {
                return Receiver.IsFileReceiving;
            }
            set
            {
                Receiver.IsFileReceiving = value;
            }
        }
        public bool IsListening
        {
            get
            {
                return Receiver.IsListening;
            }
            set
            {
                Receiver.IsListening = value;
            }
        }

        public void ListenForRequest()
        {
            Receiver.ListenForRequest();
        }

        public void SendFile()
        {
            Sender.SendFile();
        }

        public void CancelListeningFile()
        {
            Receiver.CancelListeningFile();
        }

        public void CancelReceivingFile()
        {
            Receiver.CancelReceivingFile();
        }

        public bool CancelSendingFile()
        {
            return Sender.CancelSendingFile();
        }

        public void Dispose()
        {
            Sender.Dispose();
            Receiver.Dispose();
        }
    }
}
