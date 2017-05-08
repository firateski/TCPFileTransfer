using System;
using System.Net;

namespace File_Transfer.Model.SenderFiles
{
    interface ISender : IDisposable
    {
        /// <summary>
        /// Gönderimin yapılacağı IP adresini tutar.
        /// </summary>
        IPAddress SendIpAdress { get; set; }

        /// <summary>
        /// Gönderimin yapılacağı adresin port numarasını tutar.
        /// </summary>
        int SendPortNumber { get; set; }

        /// <summary>
        /// Gönderimi yapılacak dosyanın dizinini tutar.
        /// </summary>
        string SendFileName { get; set; }

        /// <summary>
        /// Karşı tarafa bağlanılma aşamasında olup olmadığını belirtir.
        /// </summary>
        bool IsWaitingForConnect { get; set; }

        /// <summary>
        /// Geçerli olarak karşı tarafa dosya gönderilip gönderilmediğini belirtir.
        /// </summary>
        bool IsSending { get; set; }

        /// <summary>
        /// Dosyayı göndermek için kullanılır.
        /// </summary>
        void SendFile();

        /// <summary>
        /// Gönderme işlemini iptal etmek için kullanılır.
        /// </summary>
        /// <returns>İptal etme işlemi başarılı ise True, değilse False döndürür.</returns>
        bool CancelSendingFile();
    }
}
