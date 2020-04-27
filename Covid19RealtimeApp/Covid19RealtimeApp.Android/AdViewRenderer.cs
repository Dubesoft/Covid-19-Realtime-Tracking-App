using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Covid19RealtimeApp.Controls;
using Covid19RealtimeApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace Covid19RealtimeApp.Droid
{
    public class AdViewRenderer:ViewRenderer<AdControlView, AdView>
    {
        public AdViewRenderer(Context context) : base(context)
        { 
        }

        string adUnitId = "ca-app-pub-6555451570939158/4748639193";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;
        private AdView CreateAdView()
        {
            if(adView != null)
            {
                return adView;
            }

            adView = new AdView(Context)
            {
                AdSize = adSize,
                AdUnitId = adUnitId
            };

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;
            adView.LoadAd(new AdRequest.Builder().Build());

            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
            if (Control == null && e.NewElement != null)
            {
                SetNativeControl(CreateAdView());
            }
        }
    }
}