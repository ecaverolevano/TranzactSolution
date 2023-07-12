using System.Text.Json;
using Tranzact.Premium.Persistence.DatabaseContext;

namespace Tranzact.Premium.Persistence.Extention
{
    public static class SeedDataExtention
    {
        public static void SeedData(this PremiumDatabaseContext dbContext)
        {
            var filePath = getFilePath("BasicData");
            foreach (var path in filePath)
            {
                var premium = LoadFromFile<PlanSeedModel>(path);

                if (premium.Plans != null)
                {
                    foreach (var plan in premium.Plans)
                    {
                        dbContext.Add(plan);
                    }
                }

                if (premium.States != null)
                {
                    foreach (var state in premium.States)
                    {
                        dbContext.Add(state);
                    }
                }

                if (premium.Carriers != null)
                {
                    foreach (var carrier in premium.Carriers)
                    {
                        dbContext.Add(carrier);
                    }
                }

                if (premium.Premium != null)
                {
                    foreach (var data in premium.Premium)
                    {
                        dbContext.Add(data);
                    }

                }

                if (premium.PremiumDataPlan != null)
                {
                    foreach (var data in premium.PremiumDataPlan)
                    {
                        dbContext.Add(data);
                    }

                }

                dbContext.SaveChangesAsync();
            }

        }

        private static T LoadFromFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            var loaded = JsonSerializer.Deserialize<T>(json);

            return loaded;
        }

        private static string[] getFilePath(string path)
        {
            string seedDirectory = $"SeedData/{path}";
            if (!Directory.Exists(seedDirectory))
                throw new Exception("doesn't exist");

            return Directory.GetFiles(seedDirectory);
        }
    }
}
