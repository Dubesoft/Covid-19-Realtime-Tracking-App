using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19RealtimeApp.Models
{
    public class Nigeria
    {
        public string states { get; set; }

        public string cases { get; set; }

        public string death { get; set; }

        public string recovered { get; set; }

        public string active { get; set; }

        public CountryInfo countryInfo { get; set; }

        public string FullImageUrl => countryInfo.flag;
    }
}
