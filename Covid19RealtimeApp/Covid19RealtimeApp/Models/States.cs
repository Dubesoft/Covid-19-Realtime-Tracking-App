using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19RealtimeApp.Models
{
    public class States
    {
        public string state { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int active { get; set; }
    }
}
