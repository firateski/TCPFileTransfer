using File_Transfer.Extensions;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Transfer.LanguageManager
{
    public enum MessageCodes
    {
        //Sender Mesajları
        SenderConnectError,
        SenderConnectErrorTitle,

        SenderCouldntWriteToStream,
        SenderCouldntWriteToStreamTitle,

        SenderCancelledByUser,
        SenderCancelledByUserTitle,

        SenderCompleted,
        SenderCompletedTitle,

        SenderFailed,
        SenderFailedTitle,

        SenderArgumentNullException,
        SenderArgumentNullExceptionTitle,

        SenderArgumentException,
        SenderArgumentExceptionTitle,

        SenderPathTooLongException,
        SenderPathTooLongExceptionTitle,

        SenderDirectoryNotFoundException,
        SenderDirectoryNotFoundExceptionTitle,

        SenderIOExceptionError10054,
        SenderIOExceptionError10054Title,

        SenderIOException,
        SenderIOExceptionTitle,

        SenderUnauthorizedAccessException,
        SenderUnauthorizedAccessExceptionTitle,

        SenderException,
        SenderExceptionTitle,

        //Receiver Mesajları
        ReceiverAskForReceiveFile,
        ReceiverAskForReceiveFileTitle,
        
        ReceiverFileRejectedByUser,
        ReceiverFileRejectedByUserTitle,

        ReceiverCouldntReadStream,
        ReceiverCouldntReadStreamTitle,

        ReceiverCancelledByUser,
        ReceiverCancelledByUserTitle,

        ReceiverFailed,
        ReceiverFailedTitle,

        ReceiverCompleted,
        ReceiverCompletedTitle,

        ReceiverIOException10054,
        ReceiverIOException10054Title,

        ReceiverIOException,
        ReceiverIOExceptionTitle,

        ReceiverException,
        ReceiverExceptionTitle,

        //Controller Mesajları
        InvalidFilenameMessage,
        InvalidFilenameMessageTitle,

        InvalidIpAddressMessage,
        InvalidIpAddressMessageTitle,

        InvalidPortNumberMessage,
        InvalidPortNumberMessageTitle,

        InvalidFormInputMessage,
        InvalidFormInputMessageTitle,

        InvalidSaveLocationMessage,
        InvalidSaveLocationMessageTitle,
    }

    public static class Translator
    {
        public static string[] SupportedLanguages = new string[2] { "en", "tr" };

        public static bool CheckTheLanguageIsSupported(string languageCode)
        {
            return SupportedLanguages.Contains(languageCode == null ? string.Empty : languageCode);
        }

        public static string GetStringFromResource(string name, params string[] parameters)
        {
            try
            {
                string returnValue = string.Empty;
                return Task.Run(new Func<string>(() =>
                {
                    //Örnek Çıktı: en-US
                    string langCode = CultureInfo.CurrentCulture.ToString(); 

                    //Örnek Çıktı: en
                    string shortLangCode = langCode.Substring(0, langCode.IndexOf('-') < 0 ? 2 : langCode.IndexOf('-'));

                    if (!CheckTheLanguageIsSupported(shortLangCode))
                        shortLangCode = SupportedLanguages.Length > 0 ? SupportedLanguages[0] : "en";

                    ResourceManager resManager = new ResourceManager($"File_Transfer.LanguageManager.Languages.Lang_{shortLangCode}", typeof(View.MainView).Assembly);
                    returnValue = resManager.GetString(name);
                    return string.Format(returnValue, parameters);
                })).Result;
            }
            catch (Exception ex) { Console.Error.WriteLine(ex.Message); return string.Empty; }
        }

        public static void SetTextPropertyOfControls(Form frm)
        {
            List<Control> AllFormControls = ExtensionMethods.GetAllControls(frm).ToList();

            Control currentControl = null;
            for (int i = 0; i < AllFormControls.Count; i++)
            {
                currentControl = AllFormControls[i];

                string controlName = GetStringFromResource(currentControl.Name);
                currentControl.Text = !string.IsNullOrEmpty(controlName) ? controlName : currentControl.Text;
            }
        }
    }
}