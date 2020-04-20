using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19RealtimeApp.Models
{
    public class JohnHopkinsCSSEData
    {
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string updatedAt { get; set; }
        public Stats stats { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Stats
    {
        public string confirmed { get; set; }
        public string deaths { get; set; }
        public string recovered { get; set; }
    }
}
