using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.ApplicationInsights;

namespace AI.Android.Tests
{
    [Activity(Label = "AI.Android.Tests", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            
            ApplicationInsights.Setup("instrumentationKey");
            ApplicationInsights.Start();

            button.Click += delegate {
                button.Text = string.Format("{0} clicks!", count++);

                TelemetryManager.TrackEvent("Main event");
                TelemetryManager.TrackTrace("Test trace");
                TelemetryManager.TrackManagedException(new Exception("test exception"), true);
                TelemetryManager.TrackMetric("test metric", 100);
                TelemetryManager.TrackPageView("manualPageView");
                throw new InvalidOperationException("errrrrroooooo");
            };
            
            
        }
    }
}

