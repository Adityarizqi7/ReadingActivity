# Reading Activity API

## 1. Cara Download dan Penginstalan

#### C#

1. **Download C#**: Unduh dan instal .NET SDK terbaru dari [situs resmi .NET](https://dotnet.microsoft.com/download).
   
#### Visual Studio 2022

2. **Download Visual Studio 2022**: Unduh dan instal [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).
   
#### SQL Server Management Studio 20

3. **Download SQL Server Management Studio 20 (SSMS)**: Unduh dan instal [SQL Server Management Studio 20 (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

#### NuGet Packages

4. **Install NuGet Packages di Visual Studio**: Di Visual Studio, buka NuGet Package Manager dan instal paket-paket berikut:
   1. Microsoft.AspNetCore.Mvc.NewtonsoftJson
   2. Microsoft.EntityFrameworkCore.Design
   3. Microsoft.EntityFrameworkCore.SqlServer
   4. Microsoft.EntityFrameworkCore.Tools
   5. Newtonsoft.Json
   6. Swashbuckle.AspNetCore

#### Koneksi dengan Database

5. **Membuat Database**: Buat database terlebih dahulu di SQL Server Management Studio (SSMS).
6. **Hubungkan dengan File appsettings.json**: Hubungkan proyek dengan database Anda dengan menyesuaikan string koneksi di file `appsettings.json`.

## 2. Struktur Folder

### Controllers
Folder yang berisi file untuk mengontrol dan memproses data model seperti Create, Read, Update, Delete, Search, dan Filter.

### Data
Folder yang berisi file konfigurasi data aplikasi ke database seperti model entity dan relasi entity.

### DTOs
Folder yang berisi file model tiruan (kustomisasi model) yang digunakan untuk proses request dan response dalam API.

### Helpers
Folder yang berisi file kustomisasi class untuk keperluan tertentu seperti class untuk membuat query parameter dalam route API.

### Interface
Folder yang berisi file interface (type) dari function-function yang akan digunakan dalam repository.

### Mappers
Folder yang berisi file class untuk menginstansiasi object baru dari DTOs yang sudah dibuat sebelumnya dan kemudian disimpan ke dalam database.

### Migrations
Folder yang berisi file hasil migrasi model yang sudah dilakukan ke dalam SQL Server atau database.

### Models
Folder yang berisi file data atau entity yang akan digunakan dan dihubungkan ke SQL Server.

### Repository
Folder yang berisi file pemrosesan query SQL (Eloquent) yang digunakan dalam proses pengolahan data.

### Program.cs
File yang berisi service container dan konfigurasi protokol web.

### appsettings.json
File yang berisi konfigurasi aplikasi.

# 3. Terima Kasih
Terima kasih telah menggunakan Reading Activity API. Semangat dalam belajar dan mengembangkan proyek Anda, HELL YEAH!