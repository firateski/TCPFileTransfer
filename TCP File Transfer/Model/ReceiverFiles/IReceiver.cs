using System;
using System.Net;

namespace File_Transfer.Model.ReceiverFiles
{
    interface IReceiver : IDisposable
    {
        /// <summary>
        /// Alıcının kullanacağı IP adresini tutar.
        /// </summary>
        IPAddress ReceiveIpAdress { get; set; }

        /// <summary>
        /// Alıcının kullanacağı adresin port numarasını tutar.
        /// </summary>
        int ReceivePortNumber { get; set; }

        /// <summary>
        /// Alıcının aldığı dosyayı kaydedeceği dizindir.
        /// </summary>
        string ReceiveSaveLocation { get; set; }

        /// <summary>
        /// Karşı taraftan dosya alma aşamasında olup olmadığını belirtir.
        /// </summary>
        bool IsFileReceiving { get; set; }

        /// <summary>
        /// Karşı taraftan bağlantı beklenip beklenmediğini belirtir.
        /// </summary>
        bool IsListening { get; set; }

        /// <summary>
        /// Dosya gönderme işlemi bekler. Yanıt geldiğinde dosyayı indirmeye başlar.
        /// </summary>
        void ListenForRequest();

        /// <summary>
        /// Devam eden alım işlemini iptal eder.
        /// </summary>
        void CancelReceivingFile();

        /// <summary>
        /// Devam eden dosya bekleme işlemini iptal eder.
        /// </summary>
        void CancelListeningFile();
    }
}
