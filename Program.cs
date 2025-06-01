using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
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
            //DataSetOperation(googleApps);


            //DataVerification(googleApps);
            //GroupData(googleApps);
            GroupDataOperations(googleApps);
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




        static void DataVerification(IEnumerable<GoogleApp> googleApps)
        {
            var allOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER)
            .All(a => a.Reviews > 20);

            Console.WriteLine($"allOperaotrResult: {allOperatorResult}");

            Console.WriteLine();

            var anyOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER)
                .Any(a => a.Reviews > 2_000_000);
            Console.WriteLine($"AnyOperatorResult: {anyOperatorResult}");


        }
        static void GroupData(List<GoogleApp> googleApps)
        {
            //var categoryGroup = googleApps.GroupBy(app => app.Category);

            //foreach (var group in categoryGroup)
            //{
            //    var apps = group.ToList();
            //    Console.WriteLine($"Category: {group.Key} - Count: {group.Count()}");
            //    Display(apps);
            //    Console.WriteLine();
            //}

            var categoryGroup = googleApps.GroupBy(app => new { app.Category,app.Type});
            foreach (var group in categoryGroup)
            {
                var key= group.Key;
                var apps = group.ToList();
                Console.WriteLine($"Category: {group.Key.Category} - Type: {group.Key.Type} - Count: {group.Count()}");
                Display(apps);
                Console.WriteLine();
            }

            // var artAndDesignGroup = categoryGroup.First(g => g.Key == Category.ART_AND_DESIGN);


            //var apps = artAndDesignGroup.Select(app => app);
            //var apps = artAndDesignGroup.ToList();
            //Display(apps);

        }
        static void GroupDataOperations(List<GoogleApp> googleApps)
        {
            var categoryGroup = googleApps
                .GroupBy(app => app.Category);
                //.Where(g=> g.Min(a => a.Reviews) >= 10);

            foreach (var group in categoryGroup)
            {
                var averageReviews = group.Average(g => g.Reviews);
                var minReviews = group.Min(g =>g.Reviews);
                var maxReviews = group.Max(g => g.Reviews);

                var reviewsCount = group.Sum(g => g.Reviews);

                var allAppsFromGroupHaveRatingOfThree = group.All(a=>a.Rating > 3.0);
                Console.WriteLine($"Category: {group.Key}");
                Console.WriteLine($"averageReviews: {averageReviews}");
                Console.WriteLine($"minReviews: {minReviews}");
                Console.WriteLine($"maxReviews: {maxReviews}");
                Console.WriteLine($"allAppsFromGroupHaveRatingOfThree: {allAppsFromGroupHaveRatingOfThree}");
                Console.WriteLine( );
            }
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


