using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoList;
using TodoList.Data;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = builder.Configuration.GetValue<string>("JwtKey")
             ?? throw new Exception("JwtKey não configurado no appsettings.json");

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.MapInboundClaims = false;
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder
    .Services
        .AddControllers().ConfigureApiBehaviorOptions(options => {
            options.SuppressModelStateInvalidFilter = true;
        });

builder
    .Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen();

builder
    .Services
        .AddTransient<TokenService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ToDoListDataContext>(options => {
    options.UseSqlite(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
