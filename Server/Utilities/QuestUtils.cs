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

            string questsJsonString = File.ReadAllText(outputFile);

            QuestResult qr = JsonSerializer.Deserialize<QuestResult>(questsJsonString);

            return qr.Quests;
        }

        public static Quest GetRandomQuest()
        {
            List<Quest> quests = GetQuests();

            Random random = new Random();

            return quests[random.Next(quests.Count)];
        }
    }
}
