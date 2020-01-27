using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AddPostalCodeToService.BLL.Services;
using AddPostalCodeToService.BLL.Services.Contracts;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Entities;
using AddPostalCodeToService.DAL.UnitOfWork;
using AddPostalCodeToService.DAL.UnitOfWork.Contracts;
using AddPostalCodeToService.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddPostalCodeToService
{
    public class Program
    {
        static List<PostalCodes> listPostalCodes = new List<PostalCodes>();

        static async Task Main(string[] args)
        { 
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IPostalCodeService, PostalCodeService>()
                .AddTransient<IUnitOFWork, EfUnitOfWork>()
                .AddDbContext<ContextDb>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                        ServiceLifetime.Transient)
                .BuildServiceProvider();

            Console.WriteLine("enter path to file");

            string pathToFile = Console.ReadLine();

            using (var reader = File.OpenText($@"{pathToFile}"))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                while (csv.Read())
                {
                    var Record = csv.GetRecord<PostalCodes>();

                    listPostalCodes.Add(Record);
                }
            }

            Console.WriteLine("enter service id");

            Guid id = Guid.Parse(Console.ReadLine());

            IPostalCodeService postalCode = serviceProvider.GetService<IPostalCodeService>();
            
            await postalCode.AddPostalCodeToServiceAsync(id, listPostalCodes.Select(t=>t.Zip).ToList());
        }
    }
}
