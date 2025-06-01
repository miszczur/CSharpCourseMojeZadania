using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

// ReSharper disable UseFormatSpecifierInInterpolation

namespace CSharpCourseMojeZadania
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"C:\Users\Jakub\source\repos\CSharpCourseMojeZadania\googleplaystore1.csv";
            var googleApps = LoadGoogleAps(csvPath);

            //Display(googleApps);
            //GetData(googleApps);
            //ProjectData(googleApps);
            //DivideData(googleApps);
            //OrderData(googleApps);
            DataSetOperation(googleApps);
        }



        static void GetData(IEnumerable<GoogleApp> googleApps)
        {

            var highRatedApps = googleApps.Where(app => app.Rating > 4.6);
            var highRatedBeautyApps = highRatedApps.Where(app => app.Rating > 4.6 && app.Category == Category.BEAUTY);

            Display(highRatedBeautyApps);
            Console.WriteLine();
            var firstHighRatedApp = highRatedBeautyApps.SingleOrDefault(app => app.Reviews <200);
            Console.WriteLine(firstHighRatedApp);
        }
        static void ProjectData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.6 && app.Category == Category.BEAUTY);
            var highRatedBeautyAppsNames = highRatedBeautyApps.Select(app => app.Name);
            var dtos = highRatedBeautyApps.Select(app => new GoogleAppDto
            {
                Name = app.Name,
                Revievs = app.Reviews
            });
            foreach (var dto in dtos)
            {
                Console.WriteLine($"{dto.Name}: {dto.Revievs}");
            }
            var genres = highRatedBeautyApps.SelectMany(app => app.Genres);
            Console.WriteLine(string.Join(": ", genres));
            Console.WriteLine();
            var anonymousDtos = highRatedBeautyApps.Select(app => new
            {
                Name = app.Name,
                Revievs = app.Reviews,
                Category = app.Category
            });
            foreach (var dto in anonymousDtos)
            {
                Console.WriteLine($"{dto.Name}: {dto.Revievs} - {dto.Category}");
            }
        }
        static void DivideData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.4 && app.Category == Category.BEAUTY);
            Display(highRatedBeautyApps);
            Console.WriteLine();
            // var first5highRatedBeautyApps = highRatedBeautyApps.Take(5);
            // var first5highRatedBeautyApps = highRatedBeautyApps.TakeLast(5);
            // var first5highRatedBeautyApps = highRatedBeautyApps.TakeWhile(app => app.Reviews > 1000);
            //Display(first5highRatedBeautyApps);
            //var skipped5highRatedBeautyApps = highRatedBeautyApps.Skip(5);
            var skippedResults = highRatedBeautyApps.SkipWhile(app => app.Reviews > 1000);
            Display(skippedResults);
        }
        static void OrderData(List<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.4 && app.Category == Category.BEAUTY);
            Display(highRatedBeautyApps);
            Console.WriteLine();
            var orderedByRating = highRatedBeautyApps.OrderBy(app => app.Rating).ThenBy(app => app.Name);
            Display(orderedByRating);
            //Console.WriteLine();
            //var orderedByRatingDescending = highRatedBeautyApps.OrderByDescending(app => app.Rating);
            //Display(orderedByRatingDescending);

        }
        static void DataSetOperation(List<GoogleApp> googleApps)
        {
            var paidAppsCategories = googleApps.Where(app => app.Type == Type.Paid)
                .Select(a => a.Category)
                .Distinct();
            //Console.WriteLine($"Paid apps categories:{string.Join(", ",paidAppsCategories)}");

            var setA = googleApps.Where(a => a.Rating > 4.7 && a.Type == Type.Paid && a.Reviews > 1000);

            var setB = googleApps.Where(a => a.Name.Contains("Pro") && a.Rating > 4.6 && a.Reviews > 10000);

            Display(setA);
            Console.WriteLine("*******");
            Display(setB);

            //var appsUnion = setA.Union(setB);
            //Console.WriteLine("Apps Union:");
            //Display(appsUnion);


            //var appsIntersect = setA.Intersect(setB);
            //Console.WriteLine("Apps Intersect: ");
            //Display(appsIntersect);

            var appsExcept = setA.Except(setB);
            Console.WriteLine("Apps Except: ");
            Display(appsExcept);
        }








        static void Display(IEnumerable<GoogleApp> googleApps)
        {
            foreach (var googleApp in googleApps)
            {
                Console.WriteLine(googleApp);
            }

        }
        static void Display(GoogleApp googleApp)
        {
            Console.WriteLine(googleApp);
        }

        static List<GoogleApp> LoadGoogleAps(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<GoogleAppMap>();
                var records = csv.GetRecords<GoogleApp>().ToList();
                return records;
            }

        }

    }


}


