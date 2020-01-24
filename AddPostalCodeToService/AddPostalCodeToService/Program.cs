using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AddPostalCodeToService.BLL.Services;
using AddPostalCodeToService.BLL.Services.Contracts;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Repositories.Contracts;
using AddPostalCodeToService.DAL.UnitOfWork;
using AddPostalCodeToService.DAL.UnitOfWork.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;

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

                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(@"C:\Users\vbara2\Documents\todd.io.services\Todd.IO.PostalCode\files\ZIP.xlsx")))
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

            Guid id = Guid.Parse(Console.ReadLine());

            IPostalCodeService postalCode = serviceProvider.GetService<IPostalCodeService>();
            
            await postalCode.AddPostalCodeToServiceAsync(id, ExcelData);
        }
    }
}
