using BackendTrainingEst.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendTrainingEst.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Conneccion con SQl Server
            //var connectionString =
            //    builder.Configuration.GetConnectionString("Connection");

            //builder.Services.AddDbContext<AppDbContext>
            //    (options => options.UseSqlServer(connectionString)); 
            #endregion

            #region Coneccion con MySql

            var connectionString =
                builder.Configuration.GetConnectionString("ConnectionMySql");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString))); 
            #endregion



            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
