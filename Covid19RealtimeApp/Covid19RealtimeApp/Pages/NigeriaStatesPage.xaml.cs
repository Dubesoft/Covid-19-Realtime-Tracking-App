using Covid19RealtimeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19RealtimeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NigeriaStatesPage : ContentPage
    {
        string number = "080097000010";
        public NigeriaStatesPage(string state, string cases, string death, string recovered, string active)
        {
            InitializeComponent();

            GetNigeriaStatesDetails(state, cases, death, recovered, active);
        }

        private async void GetNigeriaStatesDetails(string state, string cases, string death, string recovered, string active)
        {
            var TableHtml = await ApiService.GetStateHtmlAsync();
            var countryInfo = await ApiService.GetCountry("Nigeria");

            var TableListRw = TableHtml[0].Descendants("tr").ToList();

            var TableListRwValue = TableListRw[2].Descendants("td").ToList();

            string[,] Cellvalues = new string[30, 5];
            string[] Cellvalues1 = new string[30];
            string[] Cellvalues2 = new string[30];
            string[] Cellvalues3 = new string[30];
            string[] Cellvalues4 = new string[30];
            string[] Cellvalues5 = new string[30];



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

            LblTotalCases.Text = Cellvalues2[29].ToString();
            LblTotalDeath.Text = Cellvalues5[29].ToString();
            LblTotalRecovered.Text = Cellvalues4[29].ToString();



            LblCountry.Text = state;
            ImgCountry.Source = countryInfo.FullImageUrl;
            LblCases.Text = cases;
            LblDeath.Text = death;
            LblActive.Text = active;
            LblRecovered.Text = recovered;
        }

        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(number);
        }
    }
}