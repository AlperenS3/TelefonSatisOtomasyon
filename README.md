# 📱 Telefon Satış Otomasyonu

## 📖 Proje Hakkında

Telefon Satış Otomasyonu, telefon mağazalarının günlük satış, stok ve müşteri işlemlerini dijital ortamda yönetebilmesi amacıyla geliştirilmiş kapsamlı bir masaüstü otomasyon sistemidir.

Uygulama, satış süreçlerini hızlandırmayı, stok takibini kolaylaştırmayı ve kullanıcıya güvenilir bir yönetim paneli sunmayı hedeflemektedir.

---

## 🚀 Temel Özellikler

### 👤 Kullanıcı Yönetimi
- Güvenli kullanıcı girişi
- Yetkilendirme sistemi
- Oturum yönetimi

### 📱 Telefon Yönetimi
- Telefon ekleme
- Telefon güncelleme
- Telefon silme
- Marka ve model yönetimi
- IMEI bilgisi kaydı
- Ürün detaylarını görüntüleme

### 📦 Stok Yönetimi
- Anlık stok takibi
- Stok giriş ve çıkış işlemleri
- Kritik stok kontrolü
- Satılan ürünlerin stoktan otomatik düşülmesi

### 👥 Müşteri Yönetimi
- Yeni müşteri kaydı
- Müşteri bilgilerini güncelleme
- Müşteri arama
- Satış geçmişini görüntüleme

### 💰 Satış İşlemleri
- Yeni satış oluşturma
- Satış kayıtlarını listeleme
- Satış geçmişini görüntüleme
- Toplam satış tutarını hesaplama

### 🔍 Arama ve Filtreleme
- Telefon adına göre arama
- Marka bazlı filtreleme
- Model bazlı filtreleme
- Müşteri arama

### 🗄️ Veritabanı İşlemleri
- SQL Server ile veri yönetimi
- İlişkisel veritabanı yapısı
- Güvenli veri saklama
- CRUD (Create, Read, Update, Delete) işlemleri

---

## 🛠 Kullanılan Teknolojiler

- C#
- Windows Forms
- .NET Framework
- Microsoft SQL Server


---

## 🗂 Proje Yapısı

```text
Telefon-Satis-Otomasyonu
│
├── TelefonSatisOtomasyonu.sln
├── README.md
├── Veritabani
│   └── TelefonSatisOtomasyonu.sql
├── TelefonSatisOtomasyonu
│   ├── Forms
│   ├── Classes
│   ├── Models
│   ├── Properties
│   └── Resources
```

---

## ⚙️ Kurulum

### 1. Depoyu klonlayın

```bash
git clone https://github.com/KULLANICI_ADIN/Telefon-Satis-Otomasyonu.git
```

### 2. Veritabanını oluşturun

- SQL Server'ı açın.
- `Veritabani` klasöründeki **TelefonSatisOtomasyonu.sql** dosyasını çalıştırın.
- Veritabanını oluşturun.

### 3. Connection String'i düzenleyin

Projedeki SQL Server bağlantısını kendi bilgisayarınıza göre güncelleyin.

Örnek:

```text
Server=.;Database=TelefonSatisOtomasyonu;Trusted_Connection=True;
```

### 4. Projeyi çalıştırın

- Visual Studio ile çözümü açın.
- Build alın.
- Uygulamayı çalıştırın.



## 🎯 Projenin Amacı

Bu proje, telefon satış mağazalarının satış süreçlerini dijital ortama taşıyarak;

- İş süreçlerini hızlandırmayı,
- Stok kontrolünü kolaylaştırmayı,
- Satış kayıtlarını düzenli tutmayı,
- Müşteri bilgilerinin güvenli şekilde saklanmasını,
- Verilerin SQL Server üzerinde güvenilir biçimde yönetilmesini

amaçlamaktadır.

---

## 👨‍💻 Geliştirici

**Alperen Sarımehmet**



Bu proje eğitim ve portföy amacıyla geliştirilmiştir.
