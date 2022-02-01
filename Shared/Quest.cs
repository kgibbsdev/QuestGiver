using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestGiver.Shared
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
         
    }
}
