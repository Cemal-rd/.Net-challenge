# OrderTrackingApp
Projenin Visual Studio Code editöründe açılması tercih edilir.

<h1>Projede Kullanılan Teknolojiler</h1>

.NET Core 6 API

MSSQL

Code First yaklaşımı ile yazılmıştır

Entity Framework Code First

Repository Design Pattern

YAPILAN SERVİSLER

FİRMA SERVİSLERİ

Ürün Servisleri

Sipariş Servisleri

<h2>Testler Swagger üzerinden yapılmıştır.</h2>

<h1>Tablolar Arası Bağlantılar</h1>

Base Entity Tablosu

![image](https://user-images.githubusercontent.com/107768783/211156805-f4bda4a2-695a-4161-ab70-7d6dd2bda6a3.png)

Product Tablosu

ürünler ve firmalar arası one to many ilişkisi vardır.

![github1](https://user-images.githubusercontent.com/107768783/211156641-f239e8f7-c1f7-47fa-9a07-9303e1043675.JPG)

Order Tablosu

sipariş ve Firma arasında One to Many ve sipariş ile ürünler arasında da One to Many ilişkisi vardır.

![github2](https://user-images.githubusercontent.com/107768783/211156708-d252aa10-b956-496f-99a8-f9cdcbfb7526.JPG)

Company Tablosu

örnek Code first yaklaşımı.

![image](https://user-images.githubusercontent.com/107768783/211157049-fe7a2b86-5ead-4d77-86d4-d8b622b3797b.png)

![github3](https://user-images.githubusercontent.com/107768783/211156744-667e71ac-c3a2-409e-a132-cd7106644295.JPG)

<h2>Swagger UI ile yapılan denemeler</h2>

![image](https://user-images.githubusercontent.com/107768783/211157120-1b7a0d7c-a4b9-4b44-a2b3-18482592a9eb.png)

Swagger üzerinden order siparişimizi verirken product id ve Company id kontrol edilmelidir.Birbiriyle eşleştirilmiş idler kullanılmalıdır.

Eğer onaylanmamış bir firmaya sipariş vermeye çalışırsanız alttaki uyarıyı alırsınız.

![image](https://user-images.githubusercontent.com/107768783/211157186-0a583fbf-fd7d-44c3-a218-bea25d236574.png)

Eğer firma permission saat aralıklarında değilse aşağıdaki uyarıyı alırsınız.

Örneğin bizim firmamızın çalışma saatleri 08:30 ve 16:45 arası ona alttaki isteği atarsak hata alırız.

![image](https://user-images.githubusercontent.com/107768783/211157304-146651bc-f65e-4cc8-8328-887854d57c23.png)


![image](https://user-images.githubusercontent.com/107768783/211157273-326b5519-5c7c-401d-ac0f-8c2ca81c1bbf.png)

Ek olarak projede Jsonserializer ile saat formatı istediğimiz şekilde alınmıştır.

![image](https://user-images.githubusercontent.com/107768783/211157325-420bb93e-5689-40cc-9aa1-47ac6044ee2d.png)

JsonIgnore ile swaggerdaki dağınıklık çözülmüştür.

![image](https://user-images.githubusercontent.com/107768783/211157493-393c8ca3-ec25-4b7b-9d8c-ee751bbf3b2d.png)

<h2>Projedeki Tüm Servisler</h2>

![image](https://user-images.githubusercontent.com/107768783/211157503-7777200a-2222-45c0-9ef9-46a1ed713eff.png)

<h2>İsteklerde özelleştirilmiş Response gönderimi</h2>

![image](https://user-images.githubusercontent.com/107768783/211157689-ac5eb467-9b9d-4b5c-b9aa-241b6664ecbe.png)





