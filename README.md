# Reading Activity API
API to Keep Reading Activities.

## Penggunaan
Buat sebuah GET, POST, PUT or DELETE dengan menggunakan URL pada server lokal kalian. Jalankan dan kamu akan mendapatkan sebuah JSON Response dengan data. Kamu dapat menguji API nya dengan contoh dibawah ini.

## Routes

<br />

## A. BOOKS API 

<br />

### Get All Books
`GET /api/books`

### Query Paramaters
| Parameter    | Type    | Deskripsi                                                   |
| ---------    | ------- | -----------------------------------------------------------
| `search`     | String  |  Search Books by keyword                                    |
| `sort_type`  | String  |  Sorting Books based on 'ASC' or 'DESC'. Default to "ASC"   |
| `per_page`   | Int     |  Limit per page. Default to 6                               |
| `page`       | Int     |  Current Page. Default to 1                                 |
| `genre`      | String  |  Filter Books by Slug of Genre                              |

```json
{
  "data": [
    {
      "id": 1,
      "title": "WHERE THE CRAWDADS SING",
      "author": "Delia Owen",
      "slug": "where-the-crawdads-sing",
      "total_pages": 373,
      "created_at": "2024-05-16T00:00:00",
      "updated_at": "2024-06-15T00:00:00",
      "activities": [
        {
          "id": 1,
          "full_name": "Dana",
          "last_page_read": 11,
          "last_place_read": "Home",
          "result": "Test result",
          "last_time_read": "2024-05-16T02:22:12.759",
          "created_at": "2024-05-16T06:49:53.7490728",
          "updated_at": "2024-05-16T06:49:53.7492566",
          "book": []
        },
      ],
      "genres": [
        {
          "id": 1,
          "name": "Adventure",
          "slug": "adventure",
          "created_at": "2024-05-16T00:00:00",
          "updated_at": "2024-05-16T00:00:00"
        }
      ]
    },
  ],
  "meta": {
    "pagination": {
      "total_items_all_page": 2,
      "total_items_current_page": 2,
      "limit_item_per_page": 6,
      "total_pages": 1
    }
  }
}
```

<br />

### Get Detail Book
`GET/api/books/id`

### Path Paramaters

| Name         | Type    | Deskripsi            |
| ---------    | ------- | ---------------------
| `id`         | int     |  The Id of the Book  |

```json
{
  "id": 1,
  "title": "WHERE THE CRAWDADS SING",
  "author": "Delia Owen",
  "slug": "where-the-crawdads-sing",
  "total_pages": 373,
  "created_at": "2024-05-16T00:00:00",
  "updated_at": "2024-06-15T00:00:00",
  "activities": [
    {
      "id": 1,
      "full_name": "Dini",
      "last_page_read": 11,
      "last_place_read": "Home",
      "result": "Test result",
      "last_time_read": "2024-05-16T02:22:12.759",
      "created_at": "2024-05-16T06:49:53.7490728",
      "updated_at": "2024-05-16T06:49:53.7492566",
      "book": []
    },
  ],
  "genres": [
    {
      "id": 1,
      "name": "Adventure",
      "slug": "adventure",
      "created_at": "2024-05-16T00:00:00",
      "updated_at": "2024-05-16T00:00:00"
    }
  ]
}
```

<br />

### Create A Book
`POST/api/books`

### Request Body

| Name         | Type         | Deskripsi                  |
| ---------    | ------------ | ---------------------------
| `title`      | String       |  Title of The Books        |
| `author`     | String       |  Author of The Books       |
| `total_pages`| Int          |  Total Pages of The Books  |
| `genre_id`   | Array of Int |  The ID of The Genres      |

<br />

### Update A Book
`PUT/api/books/id`

### Path Paramaters

| Name         | Type    | Deskripsi            |
| ---------    | ------- | ---------------------
| `id`         | int     |  The Id of the Book  |

### Request Body

| Name         | Type         | Deskripsi                  |
| ---------    | ------------ | ---------------------------
| `title`      | String       |  Title of The Books        |
| `author`     | String       |  Author of The Books       |
| `total_pages`| Int          |  Total Pages of The Books  |
| `genre_id`   | Array of Int |  The ID of The Genres      |

<br />

### Delete A Book
`DELETE/api/books/id`

### Path Paramaters

| Name         | Type    | Deskripsi            |
| ---------    | ------- | ---------------------
| `id`         | int     |  The Id of the Book  |

<br />

## B. ACTIVITIES API 

<br />

### Get All Activities
`GET /api/activities`

### Query Paramaters
| Parameter    | Type    | Deskripsi                                                   |
| ---------    | ------- | -----------------------------------------------------------
| `search`     | String  |  Search Books by keyword                                    |
| `sort_type`  | String  |  Sorting Books based on 'ASC' or 'DESC'. Default to "ASC"   |
| `per_page`   | Int     |  Limit per page. Default to 6                               |
| `page`       | Int     |  Current Page. Default to 1                                 |

```json
{
  "data": [
    {
      "id": 1,
      "full_name": "Dini",
      "last_page_read": 11,
      "last_place_read": "Home",
      "result": null,
      "last_time_read": "2024-05-16T02:22:12.759",
      "created_at": "2024-05-16T06:49:53.7490728",
      "updated_at": "2024-05-16T06:49:53.7492566",
      "book": {
        "id": 1,
        "title": "WHERE THE CRAWDADS SING",
        "slug": "where-the-crawdads-sing",
        "author": "Delia Owen",
        "total_pages": 373
      }
    },
    {
      "id": 2,
      "full_name": "Dane",
      "last_page_read": 13,
      "last_place_read": "Library",
      "result": null,
      "last_time_read": "2024-05-16T02:40:22.203",
      "created_at": "2024-05-16T09:40:38.7093487",
      "updated_at": "2024-05-16T09:40:38.7098472",
      "book": {
        "id": 1,
        "title": "WHERE THE CRAWDADS SING",
        "slug": "where-the-crawdads-sing",
        "author": "Delia Owen",
        "total_pages": 373
      }
    }
  ],
  "meta": {
    "pagination": {
      "total_items_all_page": 3,
      "total_items_current_page": 3,
      "limit_item_per_page": 6,
      "total_pages": 1
    }
  }
}
```

<br />

### Get Detail Activity
`GET/api/activities/id`

### Path Paramaters

| Name         | Type    | Deskripsi                |
| ---------    | ------- | ------------------------
| `id`         | int     |  The Id of the Activity  |

```json
{
  "id": 1,
  "full_name": "Dini",
  "last_page_read": 11,
  "last_place_read": "Home",
  "result": null,
  "last_time_read": "2024-05-16T02:22:12.759",
  "created_at": "2024-05-16T06:49:53.7490728",
  "updated_at": "2024-05-16T06:49:53.7492566",
  "book": {
    "id": 1,
    "title": "WHERE THE CRAWDADS SING",
    "slug": "where-the-crawdads-sing",
    "author": "Delia Owen",
    "total_pages": 373
  }
}
```

<br />

### Create A Activity
`POST/api/activities/book_id`

### Path Paramaters

| Name      | Type    | Deskripsi           |
| --------- | ------- | --------------------
| `book_id` | int     |  The Id of the Book |

### Request Body

| Name              | Type    | Deskripsi                     |
| ---------         | ------- | ------------------------------
| `full_name`       | String  |  Full name of Reader          |
| `last_page_read`  | String  |  Last Page Read of The Book   |
| `last_place_read` | String  |  Last Place Read of The Book  |
| `last_time_read`  | String  |  Last Time Read of The Book   |
| `result`          | String  |  Result Read The Book         |

<br />

### Update A Activity
`PUT/api/activities/id`

### Path Paramaters

| Name | Type    | Deskripsi                |
| -----| ------- | -------------------------
| `id` | int     |  The Id of the Activity  |

### Request Body

| Name              | Type    | Deskripsi                     |
| ---------         | ------- | ------------------------------
| `full_name`       | String  |  Full name of Reader          |
| `last_page_read`  | String  |  Last Page Read of The Book   |
| `last_place_read` | String  |  Last Place Read of The Book  |
| `last_time_read`  | String  |  Last Time Read of The Book   |
| `result`          | String  |  Result Read The Book         |

<br />

### Delete A Activity
`DELETE/api/activities`

### Path Paramaters

| Name         | Type    | Deskripsi            |
| ---------    | ------- | ---------------------
| `id`         | int     |  The Id of the Activity  |

<br />

### Get All Genres
`GET /api/genres`

### Query Paramaters
| Parameter    | Type    | Deskripsi                                                   |
| ---------    | ------- | -----------------------------------------------------------
| `search`     | String  |  Search Books by keyword                                    |
| `sort_type`  | String  |  Sorting Books based on 'ASC' or 'DESC'. Default to "ASC"   |
| `per_page`   | Int     |  Limit per page. Default to 6                               |
| `page`       | Int     |  Current Page. Default to 1                                 |
| `book`       | String  |  Filter Genres by Slug of book                              |

```json
{
  "data": [
    {
      "id": 1,
      "name": "Adventure",
      "slug": "adventure",
      "created_at": "2024-05-16T00:00:00",
      "updated_at": "2024-05-16T00:00:00"
    }
  ],
  "meta": {
    "pagination": {
      "total_items_all_page": 1,
      "total_items_current_page": 1,
      "limit_item_per_page": 6,
      "total_pages": 1
    }
  }
}
```

<br />

### Get Detail Genre
`GET/api/genres/id`

### Path Paramaters

| Name         | Type    | Deskripsi                |
| ---------    | ------- | ------------------------
| `id`         | int     |  The Id of the Genre  |

```json
{
  "id": 5,
  "name": "POST-THRILLER",
  "slug": "postthriller",
  "created_at": "2024-05-17T14:21:36.5442571",
  "updated_at": "2024-05-17T14:21:36.544644"
}
```

<br />

### Create A Genre
`POST/api/genres`

### Request Body

| Name   | Type    | Deskripsi      |
| ------ | ------- | ---------------
| `name` | String  |  Name of Genre |

<br />

### Update A Genre
`PUT/api/genres/id`

### Path Paramaters

| Name | Type    | Deskripsi                |
| -----| ------- | -------------------------
| `id` | int     |  The Id of the Genre  |

### Request Body

| Name   | Type    | Deskripsi      |
| ------ | ------- | ---------------
| `name` | String  |  Name of Genre |

<br />

### Delete A Genre
`DELETE/api/genres`

### Path Paramaters

| Name         | Type    | Deskripsi            |
| ---------    | ------- | --------------------- 
| `id`         | int     |  The Id of the Genre  |

<br />

## Download dan Install

### C#

1. **Download C#**: Unduh dan instal .NET SDK terbaru dari [situs resmi .NET](https://dotnet.microsoft.com/download).
   
### Visual Studio 2022

2. **Download Visual Studio 2022**: Unduh dan instal [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).
   
### SQL Server Management Studio 20

3. **Download SQL Server Management Studio 20 (SSMS)**: Unduh dan instal [SQL Server Management Studio 20 (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

### NuGet Packages

4. **Install NuGet Packages di Visual Studio**: Di Visual Studio, buka NuGet Package Manager dan instal paket-paket berikut:
   1. Microsoft.AspNetCore.Mvc.NewtonsoftJson
   2. Microsoft.EntityFrameworkCore.Design
   3. Microsoft.EntityFrameworkCore.SqlServer
   4. Microsoft.EntityFrameworkCore.Tools
   5. Newtonsoft.Json
   6. Swashbuckle.AspNetCore

### Koneksi dengan Database

5. **Membuat Database**: Buat database terlebih dahulu di SQL Server Management Studio (SSMS).
6. **Hubungkan dengan File appsettings.json**: Hubungkan proyek dengan database Anda dengan menyesuaikan string koneksi di file `appsettings.json`.

## Struktur Folder

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

# Terima Kasih
Terima kasih telah menggunakan Reading Activity API. Semangat dalam belajar dan mengembangkan proyek Anda, HELL YEAH!