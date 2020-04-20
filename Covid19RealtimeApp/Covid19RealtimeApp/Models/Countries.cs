using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19RealtimeApp.Models
{
    public class Countries
    {
        public string country { get; set; }
        public CountryInfo countryInfo { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int active { get; set; }
        public int critical { get; set; }
        public double? casesPerOneMillion { get; set; }
        public double? deathsPerOneMillion { get; set; }
        public object updated { get; set; }
        public string FullImageUrl => countryInfo.flag;

        public string SingleFullImageUrl => $"https://raw.githubusercontent.com/NovelCOVID/API/master/assets/flags/zw.png";
    }


    public class CountryInfo
    {
        public int? _id { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public double lat { get; set; }
        public double @long { get; set; }
        public string flag { get; set; }


        public string FullImageUrl { get; set; }
    }
}
