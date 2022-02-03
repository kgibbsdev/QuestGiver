using QuestGiver.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace QuestGiver.Server.Utilities
{
    public class QuestUtils
    {
        public static string GetQuestsJsonAsString()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputFile = Path.Combine(outputDirectory, "Data\\quests.json");

            string questsJsonString = File.ReadAllText(outputFile);

            return questsJsonString;
        }

        public static List<Quest> GetQuests()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputFile = Path.Combine(outputDirectory, "Data\\quests.json");

            List<Quest> quests = new List<Quest>();

            using (StreamReader reader = new StreamReader(outputFile))
            {
                string questsJsonString = reader.ReadToEnd();

                quests = JsonSerializer.Deserialize<List<Quest>>(questsJsonString);
            }
            return quests;
        }

        public static Quest GetRandomQuest()
        {
            List<Quest> quests = GetQuests();

            Random random = new Random();

            return quests[random.Next(quests.Count)];
        }

        public static void AddQuest(Quest questToAdd)
        {
            List<Quest> quests = GetQuests();

            quests.Add(questToAdd);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(quests, options);
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputFile = Path.Combine(outputDirectory, "Data\\quests.json");
            

            using (var streamWriter = new StreamWriter(outputFile))
            {
                streamWriter.WriteLine(jsonString);
            }

            return;
        }
    }
}
