# Quản lý thư viện

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

Bài tập lớn thực tập nhóm - Web application MVC - Quản lý thư viện

### Installation

Project cần có [SQL Server 2014](https://www.google.com.vn/url?sa=t&rct=j&q=&esrc=s&source=web&cd=2&cad=rja&uact=8&ved=0ahUKEwjNhoXmw4rUAhVlz1QKHeWnAq8QFggrMAE&url=https%3A%2F%2Fwww.microsoft.com%2Fen-us%2Fdownload%2Fdetails.aspx%3Fid%3D53168&usg=AFQjCNFk8NuMb2gb_2M9jFRWr8OuASky6w&sig2=Gi9EHjXj9hCLZRa7mus4iQ) và [Visual Studio 2015]() để chạy.

#### Bước 1: Download hoặc Clone project
```sh
$ git clone git@github.com:khanh96le/QuanLyThuVien.git
```
#### Bước 2: Mở project bằng Visual studio 2015

#### Bước 3: Mở file **Web.config** thay đổi Data Source trong phần **connectionString**
```sh
  <connectionStrings>
    <add name="LibraryContext" connectionString="Data Source=<YOUR_SQL_SERVER>;Initial Catalog=QuanLyThuVien;Integrated Security=SSPI;" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

Bước 4: Run project