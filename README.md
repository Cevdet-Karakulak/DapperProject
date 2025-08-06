# 📊💻 DapperDatasetProject | ASP.NET Core MVC + Dapper + MSSQL 🚀

Bu proje, **M&Y Yazılım Akademi Eğitim Danışmanlık** bünyesinde, **Murat Yücedağ**'ın eğitmenliğinde yürütülen **Full Stack .NET Core Development** eğitimi kapsamında geliştirilmiş bir büyük veri satış analiz dashboard projesidir.

> 🎯 **Hedef:** Kaggle’da yayınlanan **10 milyon satırlık Türk market satış verisi** ile gerçek zamanlı analiz, görselleştirme ve raporlama.

---

## 🛠️ Kullanılan Teknolojiler

<p align="center"> 
  <img src="https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" /> 
  <img src="https://img.shields.io/badge/ASP.NET%20Core%20MVC-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white" /> 
  <img src="https://img.shields.io/badge/Dapper-007ACC?style=for-the-badge&logo=csharp&logoColor=white" /> 
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
  <img src="https://img.shields.io/badge/Chart.js-F5788D?style=for-the-badge&logo=chartdotjs&logoColor=white" /> 
  <img src="https://img.shields.io/badge/Bootstrap%205-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white" /> 
</p>

---

## 📋 Temel Özellikler

### 📊 Dashboard Paneli
- 📈 **Satış Analizi:** En çok satan ürün/kategori/şehir, ortalama sipariş tutarı  
- 💰 **Gelir Görselleştirmesi:** Ciro, toplam satış ve sipariş adedi  
- 📍 **Bölgesel Analiz:** Bölge bazlı satış haritası ve grafikler  
- 🔄 **Gerçek Zamanlı Güncellemeler:** Filtrelere göre anlık veri güncelleme  

### 📃 Satış Listesi Sayfası
- 🔍 **Arama & Filtreleme:** Ürün, müşteri, kategori, şehir vb. alanlara göre  
- 📄 **Sayfalama (Pagination):** Her sayfada 20 kayıt, hızlı gezinme  
- 📊 **Veri Görselleştirme:** Bar, Pie ve Line grafik türleri (Chart.js)  
- ⚡ **Yüksek Performans:** Dapper ile büyük veri setinde hızlı sorgulama  

---

## 🏗️ Proje Yapısı


---

## 🔗 Dataset Kaynağı

- **Kaggle Dataset:** *10 Million Rows Turkish Market Sales Dataset*  
- **Paylaşan:** Ömer Çolakoğlu  
- **İçerik:** Ürün, müşteri, sipariş tarihi, bölge, şehir, kategori, fiyat vb.

---

## 🧩 Kullanım Senaryoları

- 📊 **Dashboard:** Satışları analiz et, grafiklerle özetle  
- 📋 **Filtrelenebilir Liste:** İstediğin kritere göre detaylı veri çek  
- 🔎 **Detaylı Raporlama:** Marka, yaş grubu, bölge bazlı satış performansı  

---

## 📸 Ekran Görüntüleri 

<img width="1900" height="902" alt="Image" src="https://github.com/user-attachments/assets/7396ce74-5e04-4162-8336-64d2d170c6d9" />

<img width="1724" height="482" alt="Image" src="https://github.com/user-attachments/assets/079c4049-7f83-4827-b6a1-03bae5b66278" />

<img width="1810" height="900" alt="Image" src="https://github.com/user-attachments/assets/713c8982-b770-47e6-9382-24f63d68a09d" />

<img width="1901" height="902" alt="Image" src="https://github.com/user-attachments/assets/34c6209c-174a-4a07-be61-70ec7ea10ad7" />

<img width="1891" height="910" alt="Image" src="https://github.com/user-attachments/assets/953507f8-96d6-447b-93ae-7d706734f484" />

<img width="1899" height="913" alt="Image" src="https://github.com/user-attachments/assets/8e5cb443-e9b1-4b69-8f57-4946aa18ce87" />
---

## ⚙️ Kurulum Talimatları

```bash
# Projeyi klonla
git clone https://github.com/kullaniciadi/DapperDatasetProject

# Projeyi aç
cd DapperDatasetProject

# NuGet paketlerini yükle
dotnet restore

# SQL bağlantı ayarını yap (appsettings.json)

# Uygulamayı çalıştır
dotnet run

# 📌 Notlar & Geliştirici Bilgileri
Tüm veritabanı işlemleri Dapper ORM ile yapılmıştır.

DTO yapısı ve optimize sorgular sayesinde büyük veri setleri ile yüksek performans.

Katmanlı mimari ilkesine uygun temiz kod yapısı.

✨ Geliştirici
💻 [Cevdet Karakulak - (https://www.linkedin.com/in/cevdet/)]
Proje kapsamında soru, öneri ve katkılarınızı memnuniyetle karşılarım!
