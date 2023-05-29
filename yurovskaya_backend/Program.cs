
using yurovskaya_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.EntityFrameworkCore.Sqlite;
//using Microsoft.Extensions.DependencyInjection;
//using yurovskaya_backend.Models;
//using Microsoft.EntityFrameworkCore;

namespace yurovskaya_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddDbContext<DizContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DizContext")));
            builder.Services.AddDbContext<OrderContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DizContext")));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = authorization.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authorization.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authorization.SigningKey,

                    ValidateLifetime = true,
                };
            }
 );
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}