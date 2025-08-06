# 📊💻 DapperDatasetProject | ASP.NET Core MVC + Dapper + MSSQL 🚀
Bu proje, M&Y Yazılım Akademi Eğitim Danışmanlık bünyesinde, Murat Yücedağ'ın eğitmenliğinde yürütülen Full Stack .NET Core Development eğitimi kapsamında geliştirilmiş bir büyük veri satış analiz dashboard projesidir.

**Hedef:** Projenin temelinde Kaggle üzerinde paylaşılan 10 milyon satırlık Türk market satış verisi ile gerçek zamanlı analiz, görselleştirme ve raporlama işlevleri yer almaktadır.

---

 ## 🛠️ Kullanılan Teknolojiler
<p align="center"> 
  <img src="https://img.shields.io/badge/.NET%207-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" /> 
  <img src="https://img.shields.io/badge/ASP.NET%20Core%20MVC-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white" /> 
  <img src="https://img.shields.io/badge/Dapper-007ACC?style=for-the-badge&logo=csharp&logoColor=white" /> 
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
  <img src="https://img.shields.io/badge/Chart.js-F5788D?style=for-the-badge&logo=chartdotjs&logoColor=white" /> 
  <img src="https://img.shields.io/badge/Bootstrap%204-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white" /> 
</p>

---

## 📋 Temel Özellikler

# 📊 Dashboard Paneli
📈 Satış Analizi	En çok satan ürün/kategori/şehir, ortalama sipariş tutarı
💰 Gelir Görselleştirmesi	Ciro, toplam satış ve toplam sipariş adedi
📍 Bölgesel Analiz	, bölge bazlı satış haritası ve grafikler
🔄 Gerçek Zamanlı Güncellemeler	Filtrelere göre anlık veri güncellemesi

---

# 📃 Satış Listesi Sayfası
🔍 Arama & Filtreleme	Ürün, müşteri, kategori, şehir vb. alanlara göre filtreleme
📄 Sayfalama (Pagination)	Her sayfada 20 kayıt, hızlı gezinme
📊 Veri Görselleştirme	Bar, Pie ve Line grafik türleri (Chart.js)
⚡ Yüksek Performans	Dapper ile büyük veri setinde hızlı sorgulama

---

# 🏗️ Proje Yapı Şeması

DapperDatasetProject/
├── Controllers/
│   └── SalesController.cs
├── Models/
│   └── Sales.cs
├── DTOs/
│   └── SalesDto.cs, DashboardDto.cs
├── Services/
│   └── SalesService.cs
├── Context/
│   └── DapperContext.cs
├── Views/
│   └── Dashboard.cshtml, List.cshtml
├── wwwroot/
│   └── CSS, JS, görseller
├── appsettings.json
└── Program.cs / Startup.cs

---

# 🔗 Dataset Kaynağı

Kaggle Dataset: 10Million Rows Turkish Market Sales Dataset
Paylaşan: Ömer Çolakoğlu
İçerik: Ürün, müşteri, sipariş tarihi, bölge, şehir, kategori, fiyat vb.

---

# 🧩 Kullanım Senaryoları

📊 Dashboard	Satışları analiz et, grafiklerle özetle
📋 Filtrelenebilir Liste	İstediğin kritere göre detaylı veri çek
🔎 Detaylı Raporlama	Marka, yaş grubu, bölge bazlı satış performansı

---

📸 Ekran Görüntüleri


# ⚙️ Kurulum Talimatları
bash
Kopyala
Düzenle
# Projeyi klonla
git clone https://github.com/kullaniciadi/DapperDatasetProject

# Projeyi aç
cd DapperDatasetProject

# Gerekli NuGet paketlerini yükle
dotnet restore

# SQL Server bağlantını appsettings.json'da yapılandır

# Uygulamayı çalıştır
dotnet run

# 📌 Notlar & Geliştirici Bilgileri
Tüm veritabanı işlemleri Dapper ORM ile yapılmıştır.

DTO yapısı ve optimize sorgular sayesinde büyük veri setleri ile yüksek performans.

Katmanlı mimari ilkesine uygun temiz kod yapısı.

✨ Geliştirici
💻 [Cevdet Karakulak - (https://www.linkedin.com/in/cevdet/)]
Proje kapsamında soru, öneri ve katkılarınızı memnuniyetle karşılarım!
