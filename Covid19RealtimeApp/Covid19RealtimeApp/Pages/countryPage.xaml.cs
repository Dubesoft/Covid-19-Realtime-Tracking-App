using Covid19RealtimeApp.Models;
using Covid19RealtimeApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19RealtimeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class countryPage : ContentPage
    {
        string number = "080097000010";

        public ObservableCollection<Countries> CountriesCollection;
        public countryPage(string country)
        {
            InitializeComponent();
            CountriesCollection = new ObservableCollection<Countries>();
            GetCountryDetail(country);
        }

        private async void GetCountryDetail(string country)
        {
            
            var countryInfo = await ApiService.GetCountry(country);
            var countries = await ApiService.GetAll();
            LblTotalCases.Text = countries.cases.ToString();
            LblTotalDeath.Text = countries.deaths.ToString();
            LblTotalRecovered.Text = countries.recovered.ToString();

           
            LblCountry.Text = countryInfo.country.ToString();
            ImgCountry.Source = countryInfo.FullImageUrl;
            LblCases.Text = countryInfo.cases.ToString();
            LblDeath.Text = countryInfo.deaths.ToString();
            LblRecovered.Text = countryInfo.recovered.ToString();
            LblActive.Text = countryInfo.active.ToString();
            LblTodayCases.Text = countryInfo.todayCases.ToString();
            LblCriticalCases.Text = countryInfo.critical.ToString();
           

            DateTime date = DateTime.Now;
            LblTodayDate.Text = string.Format("{0:D}", date);
        }

        private void PickerCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(number);
        }
    }
}