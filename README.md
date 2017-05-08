# TCPFileTransfer
## TCP Dosya Transfer
TCP protokolü kullanarak IP üzerinden dosya transferi yapar. Programın yapabildiklerini ve ileride yapabileceklerini aşağıda belirttim. Program Visual Studio 2017 ortamında C# programlama dili kullanarak geliştirilmiştir.

<b>Desteklenen Diller</b>
- [x] Türkçe
- [x] İngilizce

**Not:** Özellikle İngilizce olmak üzere dillerin geliştirmesine yardımcı olabilirsiniz.

<b>Özellikler</b>

- [x] Her türlü dosyayı transfer eder.
- [x] Transfer edilen dosyanın boyutunu ve ne kadar aktarıldığını anlık olarak gösterir.
- [x] Transfer işleminin ne kadarının tamamlandığını yüzde olarak gösterir(progressbar dahil).
- [x] Transfer hızını `birim/saniye` olarak anlık gösterir.
- [x] Dosyayı karşıdan kaydetmeye başlamadan önce dosya ismini ve boyutunu kullanıcıya göstererek onayını alır.
- [x] Transfer sırasında iptal etme özelliği vardır.
- [x] Transfer için hangi Port'un ve IP adresinin kullanılacağı belirtilebilir.

<b>Eklenebilecek Özellikler</b>

- [ ] Unit testleri yapılabilir :(
- [ ] Şu anda modemde port açan kullanıcı karşıdan gelen dosyayı karşılarken, diğer kullanıcı da bu porta dosyayı gönderiyor. Bu ayrımı ortadan kaldırıp sadece bir kişinin port açmasıyla her iki işlemin yapılmasına olanak sağlanabilir. Böylece kullanıcılardan birinin port açması her iki kullanıcının hem dosya alma hem de dosya gönderme işlemi yapmasını sağlayacaktır.
- [ ] Dosya transfer sırasında duraklatma(pause) özelliği eklenebilir.
- [ ] Dosya reddetildiğinde veya transfer iptal edildiğinde standart mesaj yerine farklı mesaj verilebilir.
- [ ] Kullanıcı arayüzü daha kullanışlı ve güzel hale getirilebilir.

<b>Ekran Görüntüleri</b>

|   |   |
|---|---|
| ![Dosya Transfer Uygulaması Ekran Görüntüsü](http://firateski.com/images/file_transfer_img0001.png) | ![Dosya Transfer Uygulaması Ekran Görüntüsü](http://firateski.com/images/file_transfer_img0002.png) |
| ![Dosya Transfer Uygulaması Ekran Görüntüsü](http://firateski.com/images/file_transfer_img0003.png) | ![Dosya Transfer Uygulaması Ekran Görüntüsü](http://firateski.com/images/file_transfer_img0004.png) |
| ![Dosya Transfer Uygulaması Ekran Görüntüsü](http://firateski.com/images/file_transfer_img0005.png) | ![Dosya Transfer Uygulaması Ekran Görüntüsü](http://firateski.com/images/file_transfer_img0006.png) |


#
<b>Programcıdan Notlar</b>
> <b>Önerilere, isteklere ve sorunların yüzüme vurulmasına açığım :)</b>

> Bu programı yapmamın asıl sebebi çevremdeki kişilerle sık sık dosya transferi yapmamız ve bunu sürekli mail veya 3. parti uygulamalarla yapmak zorunda kalmamızdır. Sonra kod yazabildiğimi hatırladım ve böyle basit bir uygulamaya yapmaya giriştim. Sonra madem giriştim; hata kontrolleriyle, kullanıcıya verilen mesajlarla ve kodların okunurluğuyla bunu biraz daha ileriye taşıyım belki kullanan olur diye düşündüm. Daha sonra kendimi Github üzerinde readme.md dosyasını düzenlerken buldum.
