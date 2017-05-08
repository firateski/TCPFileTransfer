using File_Transfer.Model.ReceiverFiles;
using File_Transfer.Model.SenderFiles;
using File_Transfer.Extensions;
using File_Transfer.LanguageManager;
using File_Transfer.Controller;

using System;
using System.IO;
using System.Windows.Forms;

namespace File_Transfer.View
{
    public partial class MainView : Form, IMainViewController
    {
        public MainView()
        {
            InitializeComponent();

            LoadTextOfControls();
        }

        MainViewController Controller;
        public void SetController(MainViewController controller)
        {
            this.Controller = controller;
        }

        public string GetInputValueOnForm(MainFormInputs input)
        {
            switch (input)
            {
                case MainFormInputs.SendIPAdress           :    return txtSendIp.Text;
                case MainFormInputs.ReceiveIPAdress        :    return txtReceiveIpAdress.Text;
                case MainFormInputs.SendPortNumber         :    return txtSendPort.Text;
                case MainFormInputs.ReceivePortNumber      :    return txtReceivePort.Text;
                case MainFormInputs.FileNameForSend        :    return txtFileLocation.Text;
                case MainFormInputs.SaveLocationForReceive :    return txtSaveLocation.Text;
                default: return string.Empty;
            }
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog dlg = new OpenFileDialog())
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(dlg.FileName);
                    labelSendingProgress.Text = $"{file.Name} / {file.Length.formatSize()}";
                    txtFileLocation.Text = file.FullName;
                }
            }
        }
        private void BtnSelectSaveLocation_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtSaveLocation.Text = dlg.SelectedPath;
                }
            }
        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            Controller.SendFileOrCancel();
        }
        private void BtnReceiveFile_Click(object sender, EventArgs e)
        {
           Controller.ReceiveFileOrCancel();
        }

        private void RedirectLinkLabels(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string redirectCode = ((LinkLabel)sender).Tag.ToString();
            string redirectUrl = string.Empty;

            switch (redirectCode)
            {
                case "github_repo": redirectUrl = "https://github.com/firateski/TCPFileTransfer"; break;
                case "firats_website": redirectUrl = "http://firateski.com"; break;
                case "firats_github_page": redirectUrl = "https://github.com/firateski/"; break;
            }

            if (!string.IsNullOrEmpty(redirectUrl))
                System.Diagnostics.Process.Start(redirectUrl);
        }

        public void FileSender_SendingFileStartedEvent()
        {
            labelSendingProgress.Text = Translator.GetStringFromResource("FileSending");
            btnSendFile.Text = Translator.GetStringFromResource("CancelSending");

            progressBarSendFile.Visible = true;
            btnSelectFile.Enabled = false;
            txtSendIp.Enabled = false;
            txtSendPort.Enabled = false;
            txtFileLocation.Enabled = false;
        }
        public void FileSender_sendingCompletedEvent(SendResult result, string message, string title)
        {
            if (result == SendResult.CannotSend)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == SendResult.Cancelled)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == SendResult.Completed)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            progressBarSendFile.Value = 0;
            btnSendFile.Text = Translator.GetStringFromResource("btnSendFile");
            labelSendingProgress.Text = string.Empty;

            progressBarSendFile.Visible = false;
            btnSelectFile.Enabled = true;
            txtSendIp.Enabled = true;
            txtSendPort.Enabled = true;
            txtFileLocation.Enabled = true;
        }
        public void FileSender_ProgressChangedEvent(long current, long total, long totalTime)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        labelSendingProgress.Text = $"{current.formatSize()} / {total.formatSize()} - {totalTime.calcSpeed(current)}";
                        progressBarSendFile.Value = current.getPercent(total);
                    }));
                }
                catch (InvalidOperationException)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
            else
            {
                labelSendingProgress.Text = $"{current.formatSize()} / {total.formatSize()} - {totalTime.calcSpeed(current)}";
                progressBarSendFile.Value = current.getPercent(total);
            }
        }

        public void FileReceiver_ListenStartedEvent()
        {
            labelReceivedProgress.Text = Translator.GetStringFromResource("WaitingForFile");
            btnReceiveFile.Text = Translator.GetStringFromResource("CancelWaiting");

            btnSelectSaveLocation.Enabled = false;
            txtReceiveIpAdress.Enabled = false;
            txtReceivePort.Enabled = false;
            txtSaveLocation.Enabled = false;
        }
        public void FileReceiver_ListenCompletedEvent(ReceiveResult result)
        {
            if (result == ReceiveResult.RequestAccepted)
            {
                labelReceivedProgress.Text = Translator.GetStringFromResource("FileRequestHasCame");
            }
            else if (result == ReceiveResult.ListeningCancelled)
            {
                //Controller.FileReceiver = null;
                btnReceiveFile.Text = Translator.GetStringFromResource("btnReceiveFile");
                labelReceivedProgress.Text = Translator.GetStringFromResource("FileWaitingWasCancelled");

                btnSelectSaveLocation.Enabled = true;
                txtReceiveIpAdress.Enabled = true;
                txtReceivePort.Enabled = true;
                txtSaveLocation.Enabled = true;
            }
        }
        public void FileReceiver_ReceivingStartedEvent()
        {
            progressBarReceiveFile.Visible = true;
            btnReceiveFile.Text = Translator.GetStringFromResource("CancelTransfer");
            labelReceivedProgress.Text = Translator.GetStringFromResource("FileRequestJustComeUpWaitingUserResponse");
        }
        public void FileReceiver_ReceivingCompletedEvent(ReceiveResult result, string message, string title)
        {
            if (result == ReceiveResult.Completed)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == ReceiveResult.FileIgnoredByUser)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == ReceiveResult.Cancelled)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == ReceiveResult.CannotReceived)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            progressBarReceiveFile.Value = 0;
            btnReceiveFile.Text = Translator.GetStringFromResource("btnReceiveFile");
            labelReceivedProgress.Text = string.Empty;

            progressBarReceiveFile.Visible = false;
            btnSelectSaveLocation.Enabled = true;
            txtReceiveIpAdress.Enabled = true;
            txtReceivePort.Enabled = true;
            txtSaveLocation.Enabled = true;
        }
        public void FileReceiver_ProgressChangedEvent(long current, long total, long totalTime)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        labelReceivedProgress.Text = $"{current.formatSize()} / {total.formatSize()} - {totalTime.calcSpeed(current)}";
                        progressBarReceiveFile.Value = current.getPercent(total);
                    }));
                }
                catch (InvalidOperationException)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
            }
            else
            {
                labelReceivedProgress.Text = $"{current.formatSize()} / {total.formatSize()} - {totalTime.calcSpeed(current)}";
                progressBarReceiveFile.Value = current.getPercent(total);
            }
        }

        private void txtFileLocation_Click(object sender, EventArgs e)
        {
            btnSelectFile.PerformClick();
        }
        private void txtSaveLocation_Click(object sender, EventArgs e)
        {
            btnSelectSaveLocation.PerformClick();
        }

        private void LoadTextOfControls()
        {
            //Parametre gerektirmeyen tüm kontrolleri kapsar.
            Translator.SetTextPropertyOfControls(this);

            //Parametre gerektiren statik kontrolleri kapsar.
            string AppName = Translator.GetStringFromResource("AppName");
            string CurrentYear = DateTime.Now.Year.ToString();
            string CurrentVersion = Application.ProductVersion;

            labelAppNameAndVersion.Text = Translator.GetStringFromResource(labelAppNameAndVersion.Name.ToString(),
                                          AppName,
                                          CurrentVersion);

            labelAppGithubRepository.Text = Translator.GetStringFromResource(labelAppGithubRepository.Name,
                                           AppName);

            labelAllRightReserved.Text = Translator.GetStringFromResource(labelAllRightReserved.Name,
                                         CurrentYear,
                                         AppName);
        }
    }
}
