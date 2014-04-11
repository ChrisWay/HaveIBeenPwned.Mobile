using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveIBeenPwned.Mobile.Core.Models
{
    public class Breach
    {
        public Breach()
        {
            DataClasses = new List<string>();
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public DateTime BreachDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int PwnCount { get; set; }
        public string Description { get; set; }
        public List<string> DataClasses { get; set; }
    }
}
