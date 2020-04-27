using Covid19RealtimeApp.Models;
using Covid19RealtimeApp.Services;
using HtmlAgilityPack;
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
    public partial class NigeriaPage : ContentPage
    {
        string TotalValue = "";
       
        public ObservableCollection<HtmlNode> NigerianStatesCollection;
        public NigeriaPage()
        {
            InitializeComponent();
            NigerianStatesCollection = new ObservableCollection<HtmlNode>();
            GetNigerianStates();
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            GetNigerianStates();
        }
        private async void GetNigerianStates()
        {
            var TableHtml = await ApiService.GetStateHtmlAsync();
            var countryInfo = await ApiService.GetCountry("Nigeria");

            var TableListRw = TableHtml[0].Descendants("tr").ToList();

            var TableListRwValue = TableListRw[1].Descendants("td").ToList();


            string[,] Cellvalues = new string[TableListRw.Count, TableListRwValue.Count];
            string[] Cellvalues1 = new string[TableListRw.Count];
            string[] Cellvalues2 = new string[TableListRw.Count];
            string[] Cellvalues3 = new string[TableListRw.Count];
            string[] Cellvalues4 = new string[TableListRw.Count];
            string[] Cellvalues5 = new string[TableListRw.Count];


            for (int i = 0; i < TableListRw.Count; i++)
            {
                var TableListRwValue3 = TableListRw[0].Descendants("th").ToList();
                var TableListRwValue2 = TableListRw[i].Descendants("td").ToList();
                for (int j = 0; j < TableListRwValue2.Count; j++)
                {
                    Cellvalues[i, j] = TableListRwValue2[j].Descendants("p").FirstOrDefault().InnerText.Trim('\r', '\n', '\t');
                }
            }


            for (int i = 1; i < TableListRw.Count; i++)
            {
                Cellvalues1[i] = Cellvalues[i, 0];
                Cellvalues2[i] = Cellvalues[i, 1];
                Cellvalues3[i] = Cellvalues[i, 2];
                Cellvalues4[i] = Cellvalues[i, 3];
                Cellvalues5[i] = Cellvalues[i, 4];
            }


            DateTime date = DateTime.Now;
            LblTodayDate.Text = string.Format("{0:D}", date);

            var nigeria = new List<Nigeria>();

            for(int i = 1; i < TableListRw.Count; i++)
            {
                nigeria.Add(new Nigeria { states = Cellvalues1[i], cases = Cellvalues2[i], death = Cellvalues5[i], recovered = Cellvalues4[i]});
            }
            TotalValue = Cellvalues3[TableListRw.Count - 1].ToString();
            LblTotalCases.Text = Cellvalues2[TableListRw.Count -1].ToString();
            LblTotalDeath.Text = Cellvalues5[TableListRw.Count - 1].ToString();
            LblTotalRecovered.Text = Cellvalues4[TableListRw.Count - 1].ToString();
            //ImgCountry.Source = countryInfo.FullImageUrl;
            LvNigerianStates.ItemsSource = nigeria;
            //Console.WriteLine();
        }


      

        private void SearchBarStates_SearchButtonPressed(object sender, EventArgs e)
        {

        }

       

        private async void LvNigerianStates_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Nigeria;
            await Navigation.PushModalAsync(new NigeriaStatesPage(item.states, item.cases, item.death, item.recovered, TotalValue.ToString()));
        }
    }
}