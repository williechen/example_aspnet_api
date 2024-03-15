建立 Web API 專案 
  dotnet new webapi -n QADemo -lang "C#" -f net8.0

建立 Class Lib 專案
  dotnet new classlib -n QADemo.Domain -lang "C#" -f net8.0

建立 angular 專案
  dotent new angular -n QADemo.Web

建立專案參考
  cd QADemo --主專案
  dotnet add reference ../QADemo.Domain

新增 controller 
  cd QADemo/Areas/Question/controller
  dotent new apicontroller

新增 class 
  cd QADemo/Areas/Question/Service
  dotent new class 

安裝套件
  JwtBearer
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
  Authorization 
    dotnet add package Microsoft.AspNetCore.Authorization
  EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
  Postgresql
    dotnet add package Npgsql.EntityFrameworkCore.Postgresql
    dotnet add package Npgsql.EntityFrameworkCore.Postgresql.Design
  Injection
    dotnet add package Microsoft.Extensions.DependencyInjection
    dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
  Dapper(SQL -> Object)
    dotnet add package Dapper
  SFTP
    dotnet add package ssh.net

資料庫連線
  DefaultConnection: "Server=localhost;Port=5432;Database=yourDataBase;User Id=yourUseId;Password=yourPassword"

從資料庫已存在的 Schema 產生對應的 dbcontext
  dotnet ef dbcontext scaffold "Host=localhost;Database=postgres;Username=postgres;Password=psg1234;Trust Server Certificate=true" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -f
