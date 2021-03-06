﻿using Covid19RealtimeApp.Models;
using Covid19RealtimeApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19RealtimeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesPage : ContentPage
    {

        public ObservableCollection<Countries> CountriesCollection;

        private void LvCountries_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as Countries;
            Navigation.PushModalAsync(new countryPage(selectedItem.country));
        }


        private async void SearchBarCountry_SearchButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new countryPage(SearchBarCountry.Text));
        }

        public CountriesPage()
        {
            InitializeComponent();
            CountriesCollection = new ObservableCollection<Countries>();
            GetCountries();
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            GetCountries();
        }
        private async void GetCountries()
        {
            var totalCountry = await ApiService.GetAll();

            var countries = await ApiService.GetCountries();
            foreach (var country in countries)
            {
                CountriesCollection.Add(country);
            }
            LvCountries.ItemsSource = CountriesCollection;
            LblTotalCases.Text = totalCountry.cases.ToString();
            LblTotalDeath.Text = totalCountry.deaths.ToString();
            LblTotalRecovered.Text = totalCountry.recovered.ToString();

            DateTime date = DateTime.Now;
            LblTodayDate.Text = string.Format("{0:D}", date);
        }

       
    }
}