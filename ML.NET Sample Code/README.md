# Proyek Prediksi Harga Rumah dengan ML.NET

Proyek ini menggunakan **ML.NET** untuk memprediksi harga rumah berdasarkan berbagai fitur seperti luas, jumlah kamar tidur, kamar mandi, dan lain-lain. Panduan langkah demi langkah berikut akan membantu Anda mempersiapkan dan menjalankan proyek ini di **Visual Studio**.

## Persyaratan

Sebelum menjalankan proyek, pastikan Anda sudah menginstal:

- **Visual Studio 2022 atau versi lebih baru** (dengan workload `.NET desktop development`)
- **.NET SDK** (disarankan: .NET 5.0 atau lebih baru)
- **Paket NuGet ML.NET** untuk fungsi machine learning

## Panduan Langkah demi Langkah

### 1. Membuka Proyek di Visual Studio

1. Buka **Visual Studio**.
2. Pilih menu **File > Open > Project/Solution**.
3. Cari folder tempat proyek disimpan.
4. Pilih file **`.sln`** (misalnya `MLNET_Sample_Code.sln`) dan klik **Open**.
5. Tunggu sampai Visual Studio selesai memuat proyek dan mengunduh paket NuGet yang diperlukan.

### 2. Memulihkan Paket NuGet

Visual Studio biasanya akan otomatis memulihkan paket NuGet. Jika belum:

1. Klik kanan pada solusi di **Solution Explorer**.
2. Pilih **Restore NuGet Packages** agar semua dependensi terunduh.

### 3. Menginstal Paket NuGet ML.NET

Jika paket ML.NET belum terpasang:

1. Buka **Tools > NuGet Package Manager > Manage NuGet Packages for Solution**.
2. Cari paket **`Microsoft.ML`** pada tab **Browse**, lalu klik **Install**.

### 4. Membangun Proyek

1. Klik **Build > Build Solution** atau tekan `Ctrl + Shift + B`.
2. Pastikan proses build selesai tanpa error.

### 5. Memperbarui Jalur File CSV (jika perlu)

File data `Housing.csv` harus disimpan di lokasi yang benar. Default path di kode adalah:

```csharp
"C:\\ML.NET Sample Code\\ML.NET Sample Code\\Housing.csv"
```

1. Pastikan file **`Housing.csv`** ada pada direktori tersebut.
2. Jika ingin memindahkan file, update path pada kode berikut:

```csharp
var trainData = context.Data.LoadFromTextFile<HouseData>(
    "path_ke_file_Housing.csv", separatorChar: ',', hasHeader: true);
```

### 6. Menjalankan Proyek

1. Tekan **F5** atau pilih **Debug > Start Debugging** untuk menjalankan aplikasi konsol.
2. Program akan memuat data, melatih model, dan menampilkan hasil evaluasi performa model, misalnya:

```
Columns in the dataset:
Column name: Price, Column type: Single
Column name: Area, Column type: Single
...
R^2: 0.6131
Root Mean Squared Error: 1029759
```

### 7. Memahami Output

Setelah selesai, Anda akan melihat metrik performa model:

- **R² (Koefisien Determinasi)**: Nilai mendekati 1 menunjukkan model fit dengan data.
- **RMSE (Root Mean Squared Error)**: Nilai rendah berarti prediksi model semakin akurat.

Panduan ini dirancang untuk memudahkan siapa saja yang baru pertama kali menggunakan proyek ini, mulai dari membuka solusi hingga menilai performa model.

---
