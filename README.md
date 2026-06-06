# Bootcamp LKS 2024

Repository ini berisi kumpulan proyek latihan dan simulasi yang dikerjakan selama persiapan Lomba Kompetensi Siswa (LKS) bidang IT Software Solution for Business tahun 2024.

Proyek mencakup tiga kategori utama: **Desktop Application**, **Mobile Application**, dan **Web Service (REST API)**.

---

## Struktur Folder

```
Bootcamp LKS 2024/
├── Dekstop/
│   ├── BromoairlinessV1/           # Aplikasi desktop manajemen pemesanan tiket pesawat
│   ├── EsemkaBromo/                # Aplikasi desktop tema Bromo
│   ├── EsemkaCinema/               # Aplikasi desktop manajemen bioskop
│   ├── EsemkaFoodcourt-Latihan/    # Latihan aplikasi desktop foodcourt
│   ├── EsemkaFoodcourtV1/          # Versi final aplikasi desktop foodcourt
│   ├── EsemkaPolling/              # Aplikasi desktop sistem polling/voting
│   ├── Foodcourt(latihan)/         # Latihan awal aplikasi foodcourt
│   └── SimulasiLKSpolling/         # Simulasi soal LKS untuk aplikasi polling
│
├── Mobile/
│   ├── EsemkaBakeryV2/             # Aplikasi mobile toko roti (Kotlin - Android)
│   ├── EsemkaPetitionV2/           # Aplikasi mobile sistem petisi (Kotlin - Android)
│   ├── EsemkaRecipes/              # Aplikasi mobile resep makanan (Kotlin - Android)
│   ├── EsemkaStorelatihan/         # Latihan aplikasi mobile toko
│   ├── EzemKofiTry/                # Latihan aplikasi mobile kafe
│   └── LatihanLKS/                 # Latihan umum mobile development
│
├── Web Service/
│   ├── Web-API-LKS/                # REST API bertema hero game (ASP.NET Core)
│   ├── WebAPI/                     # REST API latihan umum (ASP.NET Core)
│   ├── EsemkaHero-Spedtest/        # Speed test REST API tema hero
│   └── Soal Soal LKS/             # Kumpulan soal referensi web service
│
└── SOAL/
    ├── BromoAirlines_TP.pdf
    ├── EsemkaCorporation_TP.pdf
    ├── EsemkaFoodcourt_TP.pdf
    ├── EsemkaRailways.pdf
    ├── EzemKofi_TP.pdf
    ├── IT SOFTWARE - LKS 2018.pdf
    ├── Soal LKS 2022 - IT Software Solution for Business.pdf
    ├── Soal LKS Nasional 2020.pdf
    └── pdf-soal-lks-provinsi-2023.pdf
```

---

## Penjelasan Per Kategori

### Desktop Application

Dibangun menggunakan **C# Windows Forms** dengan **.NET Framework** dan **Entity Framework** sebagai ORM untuk koneksi ke database SQL Server.

Setiap proyek desktop umumnya memiliki struktur sebagai berikut:

```
NamaProyek/
├── NamaProyek.sln              # Solution file Visual Studio
└── NamaProyek/
    ├── Form1.cs                # Form login utama
    ├── AdminMainForm.cs        # Dashboard admin
    ├── CustomerMainForm.cs     # Dashboard customer
    ├── Model1.edmx             # Entity Data Model (mapping database)
    ├── *.cs                    # Model entitas (Akun, Bandara, Maskapai, dll.)
    ├── Properties/             # Metadata proyek
    ├── Resources/              # Aset gambar dan ikon
    ├── bin/                    # Output binary hasil build
    └── obj/                    # File intermediate compiler
```

---

### Mobile Application

Dibangun menggunakan **Kotlin** untuk platform **Android** dengan **Android Studio**. Setiap proyek mengikuti struktur standar Android Gradle.

```
NamaProyek/
├── build.gradle.kts            # Konfigurasi build level proyek
├── settings.gradle.kts         # Konfigurasi modul
├── gradle.properties           # Properti Gradle
├── gradlew / gradlew.bat       # Gradle wrapper
└── app/
    ├── build.gradle.kts        # Konfigurasi build level modul
    └── src/
        └── main/
            ├── AndroidManifest.xml                         # Konfigurasi aplikasi Android
            ├── java/com/example/namaaplikasi/
            │   ├── MainActivity.kt                         # Entry point aplikasi
            │   ├── Home.kt                                 # Fragment/Activity halaman utama
            │   ├── Detail.kt                               # Halaman detail item
            │   ├── Search.kt                               # Halaman pencarian
            │   ├── Register.kt                             # Halaman registrasi
            │   └── order.kt                                # Halaman pemesanan
            └── res/
                ├── layout/                                 # File XML layout tampilan
                ├── drawable/                               # Aset gambar dan ikon
                ├── values/                                 # String, warna, dan tema
                └── xml/                                    # Konfigurasi tambahan
```

---

### Web Service (REST API)

Dibangun menggunakan **ASP.NET Core** dengan **C#** dan **Entity Framework Core** sebagai ORM. API mengikuti pola arsitektur **Controller - DTO - Database**.

```
NamaProyek/
├── NamaProyek.sln              # Solution file Visual Studio
└── NamaProyek/
    ├── Program.cs              # Entry point aplikasi, konfigurasi middleware dan DI
    ├── appsettings.json        # Konfigurasi aplikasi (connection string, dll.)
    ├── appsettings.Development.json  # Konfigurasi khusus environment development
    ├── NamaProyek.csproj       # File project (.NET), berisi dependency NuGet
    ├── Controllers/            # Berisi controller untuk setiap endpoint resource
    │   ├── HeroesController.cs
    │   ├── SkillsController.cs
    │   ├── ClannnController.cs
    │   ├── ElementsController.cs
    │   ├── HeroSkillsController.cs
    │   └── FightHistoriesController.cs
    ├── DTO/                    # Data Transfer Object untuk validasi request dan format response
    │   ├── Request/            # DTO untuk body request (POST, PUT)
    │   └── Response/           # DTO untuk struktur response JSON
    ├── Database/               # DbContext dan model entitas database
    │   ├── NamaContext.cs      # Entity Framework DbContext
    │   ├── Hero.cs
    │   ├── Skill.cs
    │   ├── Clan.cs
    │   ├── Element.cs
    │   ├── HeroSkill.cs
    │   └── FightHistory.cs
    ├── Properties/             # Konfigurasi launch profile
    ├── bin/                    # Output binary hasil build
    └── obj/                    # File intermediate compiler
```

---

### SOAL

Berisi kumpulan soal LKS dari berbagai tahun dan tingkatan (Wilker, Provinsi, Nasional) dalam format PDF. Digunakan sebagai referensi latihan dan pemahaman standar kompetensi.

---

## Teknologi yang Digunakan

| Kategori | Teknologi |
|---|---|
| Desktop Application | C#, Windows Forms, .NET Framework, Entity Framework 6, SQL Server |
| Mobile Application | Kotlin, Android SDK, Gradle |
| Web Service | C#, ASP.NET Core, Entity Framework Core, SQL Server |
| IDE Desktop & Web | Visual Studio 2022 |
| IDE Mobile | Android Studio |
