# Aplikasi Chatbot Menggunakan MAUI dan Azure OpenAI

Panduan ini memberikan langkah-langkah detail untuk mengintegrasikan Azure OpenAI ke dalam aplikasi chatbot yang dibangun menggunakan MAUI (Multi-platform App UI) di Visual Studio 2022. Ikuti langkah-langkah berikut untuk menyiapkan dan menerapkan aplikasi chatbot.

## Persiapan Awal

Sebelum memulai, pastikan Anda memiliki:

- Instalasi Visual Studio 2022 dengan dukungan MAUI.
- Akun Azure yang aktif.
- Pengetahuan dasar tentang pengembangan aplikasi C# dan MAUI.

## Panduan Langkah demi Langkah

### Langkah 1: Buka Azure Portal

1. Buka browser Anda dan kunjungi [Azure Portal](https://portal.azure.com).

### Langkah 2: Buat Resource Azure OpenAI

1. Pada kolom pencarian, ketik **Azure OpenAI** dan pilih **Azure OpenAI** dari layanan yang tersedia.
2. Klik **Create Resource** untuk memulai pembuatan resource Azure OpenAI baru.

### Langkah 3: Atur Resource Azure OpenAI Anda

1. **Resource Name**: Masukkan nama untuk resource Anda (misal: `ChatbotOpenAI`).
2. **Region**: Pilih **East US 2** sebagai region.
3. **Pricing Tier**: Pilih **Standard**.
4. Klik **Next** lalu klik **Create Resource**. Tunggu hingga proses pembuatan resource selesai.

### Langkah 4: Akses Resource Azure OpenAI

1. Setelah resource dibuat, buka halaman **Resource** untuk instance Azure OpenAI yang baru saja dibuat.

### Langkah 5: Jelajahi Azure AI Foundry

1. Di halaman resource Azure OpenAI, klik **Explore Azure AI Foundry**.

### Langkah 6: Deploy Model GPT-3.5-Turbo

1. Pada bagian **Model Catalog**, cari dan pilih **GPT-3.5-turbo**.
2. Klik **Create Resource and Deploy**. Tunggu sampai proses pembuatan resource selesai.

### Langkah 7: Salin Endpoint dan API Key

1. Di sisi kanan halaman, cari bagian **Endpoint**.
2. Salin **Target URI** (ini adalah URL endpoint).
3. Salin **API Key** yang diberikan oleh Azure OpenAI.

### Langkah 8: Buka Proyek MAUI Anda di Visual Studio

1. Buka **Visual Studio 2022** dan muat proyek Anda yaitu **ChatGPT API.sln**.

### Langkah 9: Konfigurasikan API Key dan Endpoint di Kode

1. Pada file **MainPage.xaml.cs**, cari bagian tempat API key dan endpoint didefinisikan:

   ```csharp
   string apiKey = "<YOUR API KEY HERE>";  // Ganti dengan API Key Anda
   string endpoint = "https://your-endpoint.cognitiveservices.azure.com/";  // Ganti dengan Endpoint Anda
   ```

2. Ganti placeholder **<YOUR API KEY HERE>** dengan API key yang sudah Anda salin dari portal Azure.
3. Ubah URL endpoint, pastikan yang diubah hanya bagian **subdomain** (misalnya `your-endpoint`):

   ```csharp
   string apiKey = "your-api-key";  // Tempel API Key asli Anda di sini
   string endpoint = "https://your-endpoint.cognitiveservices.azure.com/";  // Ganti subdomain
   ```

### Langkah 10: Jalankan Proyek

1. Setelah menyimpan perubahan, klik **Run** di Visual Studio untuk membangun dan menjalankan proyek.
2. Tunggu sampai proses build selesai, aplikasi akan siap digunakan untuk berinteraksi dengan model Azure OpenAI.

### Langkah 11: Uji Chatbot Anda

1. Setelah aplikasi berjalan dengan sukses, Anda bisa mulai berinteraksi dengan chatbot yang didukung oleh GPT-3.5-turbo.
2. Masukkan pertanyaan Anda, dan chatbot akan memberikan jawaban menggunakan API Azure OpenAI.

## Kesimpulan

Selamat! Anda telah berhasil mengintegrasikan Azure OpenAI ke dalam aplikasi chatbot berbasis MAUI. Sekarang Anda bisa mengembangkan dan menambah kemampuan chatbot, seperti menambahkan intent khusus, peningkatan penanganan error, dan interaksi pengguna yang lebih kompleks.

---
