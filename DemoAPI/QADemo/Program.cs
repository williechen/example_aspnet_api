using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QADemo.Domain.Bases;
using QADemo.Module.MailMod.Option;
using QADemo.Module.SftpMod.Option;
using QADemo.Registers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            //.WithOrigins("https://localhost:44387", "")
            //.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyHeader()
            .WithExposedHeaders("content-disposition")
            .AllowAnyMethod();
        //.AllowCredentials();
    });
});

builder.Services.AddDbContext<RustwebdevContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
ServiceRegister.NewService(builder.Services);
SupportRegister.NewService(builder.Services);
DaoRegister.NewDataAccessObject(builder.Services);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
        options.IncludeErrorDetails = true; // 預設值為 true，有時會特別關閉

        options.TokenValidationParameters = new TokenValidationParameters
        {
            // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
            NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
            // 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

            // 一般我們都會驗證 Issuer
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),

            // 通常不太需要驗證 Audience
            ValidateAudience = false,
            //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

            // 一般我們都會驗證 Token 的有效期間
            ValidateLifetime = true,

            // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
            ValidateIssuerSigningKey = false,

            // "1234567890123456" 應該從 IConfiguration 取得
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SignKey")))
        };
    });

builder.Services.AddAuthorization();

#region Mail
{
    var section = builder.Configuration.GetSection(MailOption.Section);
    builder.Services.Configure<MailOption>(options =>
    {
        options.Host = section.GetValue<string>(nameof(MailOption.Host))!;
        options.Port = section.GetValue<int>(nameof(MailOption.Port))!;
        options.Username = section.GetValue<string>(nameof(MailOption.Username))!;
        options.Password = section.GetValue<string>(nameof(MailOption.Password))!;
    });
}
#endregion

#region Sftp
{
    var section = builder.Configuration.GetSection(SftpOption.Section);
    builder.Services.Configure<SftpOption>(options =>
    {
        options.Host = section.GetValue<string>(nameof(SftpOption.Host))!;
        options.Port = section.GetValue<int>(nameof(SftpOption.Port))!;
        options.Username = section.GetValue<string>(nameof(SftpOption.Username))!;
        options.Password = section.GetValue<string>(nameof(SftpOption.Password))!;
    });
}
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "working...");

app.Run();

