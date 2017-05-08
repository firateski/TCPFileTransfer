using File_Transfer.View;
using File_Transfer.Model;
using File_Transfer.Controller;

using System;
using System.Windows.Forms;

namespace File_Transfer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainView MainView = new MainView();
            TransferFileEngine TransferEngine = new TransferFileEngine();

            MainViewController Controller = new MainViewController(MainView, TransferEngine);

            Application.Run(MainView);
        }
    }
}
