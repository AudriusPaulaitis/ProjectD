using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectD.Models
{
    public class TrainingModel
    {
        public int Weeks { get; set; }
        public Dictionary<string, List<string>> TrainingDict { get; set; }
        public int Time { get; set; }
    }
}
