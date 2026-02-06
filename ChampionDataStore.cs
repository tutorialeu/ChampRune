using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChampRune
{
    public static class ChampionDataStore
    {
        private static Dictionary<string, DateTime> ReleaseDates = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);
        private static string localJsonPath;

        public static void Initialize(string dataDir)
        {
            localJsonPath = Path.Combine(dataDir, "champion_dates.json");
            
            // 1. Load Hardcoded baseline if local file doesn't exist
            if (!File.Exists(localJsonPath))
            {
                var baseline = GetBaseline();
                foreach (var kvp in baseline) ReleaseDates[kvp.Key] = kvp.Value;
                SaveToLocal();
            }
            else
            {
                try
                {
                    string json = File.ReadAllText(localJsonPath);
                    var data = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(json);
                    if (data != null) ReleaseDates = new Dictionary<string, DateTime>(data, StringComparer.OrdinalIgnoreCase);
                }
                catch
                {
                    // Fallback to baseline on error
                    var baseline = GetBaseline();
                    foreach (var kvp in baseline) ReleaseDates[kvp.Key] = kvp.Value;
                }
            }
        }

        public static async Task SyncFromKerrdersAsync()
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    string json = await client.GetStringAsync("https://gist.githubusercontent.com/Kerrders/0067d88dfd982c272e20dcb496f4dbc7/raw/champions.json");
                    var data = JsonConvert.DeserializeObject<List<dynamic>>(json);
                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            string name = item.name;
                            int year = (int)item.releaseDate;
                            if (!ReleaseDates.ContainsKey(name))
                            {
                                // If new champion, use Jan 1st of that year as placeholder
                                ReleaseDates[name] = new DateTime(year, 1, 1);
                            }
                        }
                        System.Console.WriteLine("Champion release dates synced from community source.");
                        SaveToLocal();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to sync champion dates: " + ex.Message);
            }
        }

        public static void UpdateDate(string name, DateTime date)
        {
            ReleaseDates[name] = date;
            SaveToLocal();
        }

        private static void SaveToLocal()
        {
            try
            {
                string json = JsonConvert.SerializeObject(ReleaseDates, Formatting.Indented);
                File.WriteAllText(localJsonPath, json);
            }
            catch { }
        }

        public static DateTime GetReleaseDate(string name)
        {
            if (ReleaseDates.TryGetValue(name, out DateTime date)) return date;
            return DateTime.MinValue;
        }

        private static Dictionary<string, DateTime> GetBaseline()
        {
            return new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase)
            {
                { "Alistar", new DateTime(2009, 2, 21) },
                { "Annie", new DateTime(2009, 2, 21) },
                { "Ashe", new DateTime(2009, 2, 21) },
                { "Fiddlesticks", new DateTime(2009, 2, 21) },
                { "Jax", new DateTime(2009, 2, 21) },
                { "Kayle", new DateTime(2009, 2, 21) },
                { "MasterYi", new DateTime(2009, 2, 21) },
                { "Morgana", new DateTime(2009, 2, 21) },
                { "Nunu", new DateTime(2009, 2, 21) },
                { "Ryze", new DateTime(2009, 2, 21) },
                { "Sion", new DateTime(2009, 2, 21) },
                { "Sivir", new DateTime(2009, 2, 21) },
                { "Soraka", new DateTime(2009, 2, 21) },
                { "Teemo", new DateTime(2009, 2, 21) },
                { "Tristana", new DateTime(2009, 2, 21) },
                { "TwistedFate", new DateTime(2009, 2, 21) },
                { "Warwick", new DateTime(2009, 2, 21) },
                { "Singed", new DateTime(2009, 4, 18) },
                { "Zilean", new DateTime(2009, 4, 18) },
                { "Evelynn", new DateTime(2009, 5, 1) },
                { "Twitch", new DateTime(2009, 5, 1) },
                { "Tryndamere", new DateTime(2009, 5, 1) },
                { "Karthus", new DateTime(2009, 6, 12) },
                { "Amumu", new DateTime(2009, 6, 26) },
                { "Chogath", new DateTime(2009, 6, 26) },
                { "Anivia", new DateTime(2009, 7, 10) },
                { "Rammus", new DateTime(2009, 7, 10) },
                { "Shaco", new DateTime(2009, 10, 10) },
                { "DrMundo", new DateTime(2009, 9, 2) },
                { "Kassadin", new DateTime(2009, 8, 7) },
                { "Gangplank", new DateTime(2009, 8, 19) },
                { "Taric", new DateTime(2009, 8, 19) },
                { "Blitzcrank", new DateTime(2009, 9, 2) },
                { "Janna", new DateTime(2009, 9, 2) },
                { "Malphite", new DateTime(2009, 9, 2) },
                { "Corki", new DateTime(2009, 9, 19) },
                { "Katarina", new DateTime(2009, 9, 19) },
                { "Nasus", new DateTime(2009, 10, 1) },
                { "Heimerdinger", new DateTime(2009, 10, 10) },
                { "Nidalee", new DateTime(2009, 12, 17) },
                { "Udyr", new DateTime(2009, 12, 2) },
                { "Poppy", new DateTime(2010, 1, 13) },
                { "Gragas", new DateTime(2010, 2, 2) },
                { "Pantheon", new DateTime(2010, 2, 2) },
                { "Mordekaiser", new DateTime(2010, 2, 24) },
                { "Ezreal", new DateTime(2010, 3, 16) },
                { "Shen", new DateTime(2010, 3, 24) },
                { "Kennen", new DateTime(2010, 4, 8) },
                { "Garen", new DateTime(2010, 4, 27) },
                { "Akali", new DateTime(2010, 5, 11) },
                { "Malzahar", new DateTime(2010, 6, 1) },
                { "Olaf", new DateTime(2010, 6, 9) },
                { "KogMaw", new DateTime(2010, 6, 24) },
                { "XinZhao", new DateTime(2010, 7, 13) },
                { "Vladimir", new DateTime(2010, 7, 27) },
                { "Galio", new DateTime(2010, 8, 10) },
                { "Urgot", new DateTime(2010, 8, 24) },
                { "MissFortune", new DateTime(2010, 9, 8) },
                { "Sona", new DateTime(2010, 9, 21) },
                { "Swain", new DateTime(2010, 10, 5) },
                { "Lux", new DateTime(2010, 10, 19) },
                { "Leblanc", new DateTime(2010, 11, 2) },
                { "Irelia", new DateTime(2010, 11, 16) },
                { "Trundle", new DateTime(2010, 12, 1) },
                { "Cassiopeia", new DateTime(2010, 12, 14) },
                { "Caitlyn", new DateTime(2011, 1, 4) },
                { "Renekton", new DateTime(2011, 1, 18) },
                { "Karma", new DateTime(2011, 2, 1) },
                { "Maokai", new DateTime(2011, 2, 16) },
                { "JarvanIV", new DateTime(2011, 3, 1) },
                { "Nocturne", new DateTime(2011, 3, 15) },
                { "LeeSin", new DateTime(2011, 4, 1) },
                { "Brand", new DateTime(2011, 4, 12) },
                { "Rumble", new DateTime(2011, 4, 26) },
                { "Vayne", new DateTime(2011, 5, 10) },
                { "Orianna", new DateTime(2011, 6, 1) },
                { "Yorick", new DateTime(2011, 6, 22) },
                { "Leona", new DateTime(2011, 7, 13) },
                { "MonkeyKing", new DateTime(2011, 7, 26) },
                { "Skarner", new DateTime(2011, 8, 9) },
                { "Talon", new DateTime(2011, 8, 24) },
                { "Riven", new DateTime(2011, 9, 14) },
                { "Xerath", new DateTime(2011, 10, 5) },
                { "Graves", new DateTime(2011, 10, 19) },
                { "Shyvana", new DateTime(2011, 11, 1) },
                { "Fizz", new DateTime(2011, 11, 15) },
                { "Volibear", new DateTime(2011, 11, 29) },
                { "Ahri", new DateTime(2011, 12, 14) },
                { "Viktor", new DateTime(2011, 12, 29) },
                { "Sejuani", new DateTime(2012, 1, 17) },
                { "Ziggs", new DateTime(2012, 2, 1) },
                { "Nautilus", new DateTime(2012, 2, 14) },
                { "Fiora", new DateTime(2012, 2, 29) },
                { "Lulu", new DateTime(2012, 3, 20) },
                { "Hecarim", new DateTime(2012, 4, 18) },
                { "Varus", new DateTime(2012, 5, 8) },
                { "Darius", new DateTime(2012, 5, 23) },
                { "Draven", new DateTime(2012, 6, 6) },
                { "Jayce", new DateTime(2012, 7, 7) },
                { "Zyra", new DateTime(2012, 7, 24) },
                { "Diana", new DateTime(2012, 8, 7) },
                { "Rengar", new DateTime(2012, 8, 21) },
                { "Syndra", new DateTime(2012, 9, 13) },
                { "Khazix", new DateTime(2012, 9, 27) },
                { "Elise", new DateTime(2012, 10, 26) },
                { "Zed", new DateTime(2012, 11, 13) },
                { "Nami", new DateTime(2012, 12, 7) },
                { "Vi", new DateTime(2012, 12, 19) },
                { "Thresh", new DateTime(2013, 1, 23) },
                { "Quinn", new DateTime(2013, 3, 1) },
                { "Zac", new DateTime(2013, 3, 29) },
                { "Lissandra", new DateTime(2013, 4, 30) },
                { "Aatrox", new DateTime(2013, 6, 13) },
                { "Lucian", new DateTime(2013, 8, 22) },
                { "Jinx", new DateTime(2013, 10, 10) },
                { "Yasuo", new DateTime(2013, 12, 13) },
                { "Velkoz", new DateTime(2014, 2, 27) },
                { "Braum", new DateTime(2014, 5, 12) },
                { "Gnar", new DateTime(2014, 8, 14) },
                { "Azir", new DateTime(2014, 9, 16) },
                { "Kalista", new DateTime(2014, 11, 20) },
                { "RekSai", new DateTime(2014, 12, 11) },
                { "Bard", new DateTime(2015, 3, 12) },
                { "Ekko", new DateTime(2015, 5, 29) },
                { "TahmKench", new DateTime(2015, 7, 9) },
                { "Kindred", new DateTime(2015, 10, 14) },
                { "Illaoi", new DateTime(2015, 11, 24) },
                { "Jhin", new DateTime(2016, 2, 1) },
                { "AurelionSol", new DateTime(2016, 3, 24) },
                { "Taliyah", new DateTime(2016, 5, 18) },
                { "Kled", new DateTime(2016, 8, 10) },
                { "Ivern", new DateTime(2016, 10, 5) },
                { "Camille", new DateTime(2016, 12, 7) },
                { "Rakan", new DateTime(2017, 4, 19) },
                { "Xayah", new DateTime(2017, 4, 19) },
                { "Kayn", new DateTime(2017, 7, 12) },
                { "Ornn", new DateTime(2017, 8, 23) },
                { "Zoe", new DateTime(2017, 11, 21) },
                { "Kaisa", new DateTime(2018, 3, 7) },
                { "Pyke", new DateTime(2018, 5, 31) },
                { "Neeko", new DateTime(2018, 12, 5) },
                { "Sylas", new DateTime(2019, 1, 25) },
                { "Yuumi", new DateTime(2019, 5, 14) },
                { "Qiyana", new DateTime(2019, 6, 28) },
                { "Senna", new DateTime(2019, 11, 10) },
                { "Aphelios", new DateTime(2019, 12, 11) },
                { "Sett", new DateTime(2020, 1, 14) },
                { "Lillia", new DateTime(2020, 7, 22) },
                { "Yone", new DateTime(2020, 8, 6) },
                { "Samira", new DateTime(2020, 9, 21) },
                { "Seraphine", new DateTime(2020, 10, 29) },
                { "Rell", new DateTime(2020, 12, 10) },
                { "Viego", new DateTime(2021, 1, 21) },
                { "Gwen", new DateTime(2021, 4, 15) },
                { "Akshan", new DateTime(2021, 7, 22) },
                { "Vex", new DateTime(2021, 9, 23) },
                { "Zeri", new DateTime(2022, 1, 20) },
                { "Renata", new DateTime(2022, 2, 17) },
                { "Belveth", new DateTime(2022, 6, 9) },
                { "Nilah", new DateTime(2022, 7, 13) },
                { "KSante", new DateTime(2022, 11, 3) },
                { "Milio", new DateTime(2023, 3, 23) },
                { "Naafiri", new DateTime(2023, 7, 20) },
                { "Briar", new DateTime(2023, 9, 13) },
                { "Hwei", new DateTime(2023, 12, 6) },
                { "Smolder", new DateTime(2024, 1, 31) },
                { "Aurora", new DateTime(2024, 7, 17) },
                { "Ambessa", new DateTime(2024, 11, 6) },
                { "Mel", new DateTime(2025, 1, 23) },
                { "Yunara", new DateTime(2025, 7, 1) },
                { "Zaahen", new DateTime(2025, 11, 19) }
            };
        }
    }
}
