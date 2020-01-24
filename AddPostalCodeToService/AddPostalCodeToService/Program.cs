using AddPostalCodeToService.BLL.Services;
using AddPostalCodeToService.BLL.Services.Contracts;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.UnitOfWork;
using AddPostalCodeToService.DAL.UnitOfWork.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AddPostalCodeToService
{
    public class Program
    {
        static readonly List<string> ExcelData = new List<string>();

        static async Task Main(string[] args)
        { 
            var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IPostalCodeService, PostalCodeService>()
                .AddTransient<IUnitOFWork, EfUnitOfWork>()
                .AddDbContext<ContextDb>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                        ServiceLifetime.Transient)
                .BuildServiceProvider();

            Console.WriteLine("enter path to file");

            string pathToFile = Console.ReadLine();

            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo($@"{pathToFile}")))
            {
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                    {
                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            if (worksheet.Cells[i, j].Value != null)
                            { 
                                ExcelData.Add(worksheet.Cells[i, j].Value.ToString());
                            }
                        }
                    }
                }
            }

            Console.WriteLine("enter service id");

            Guid id = Guid.Parse(Console.ReadLine());

            IPostalCodeService postalCode = serviceProvider.GetService<IPostalCodeService>();
            
            await postalCode.AddPostalCodeToServiceAsync(id, ExcelData);
        }
    }
}
