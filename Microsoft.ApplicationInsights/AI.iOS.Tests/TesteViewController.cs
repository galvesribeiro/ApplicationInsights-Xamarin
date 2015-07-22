using System;
using System.Drawing;

using Foundation;
using UIKit;
using Microsoft.ApplicationInsights;

namespace AI.iOS.Tests
{
    public partial class TesteViewController : UIViewController
    {
        public TesteViewController() : base("TesteViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            ApplicationInsights.Setup("iosKTelemetryKey");
            ApplicationInsights.Start();

            TelemetryManager.TrackEvent("Main event");
            TelemetryManager.TrackTrace("Test trace");
            try
            {
                throw new InvalidOperationException("forced error");
            }
            catch (InvalidOperationException ex)
            {
                TelemetryManager.TrackManagedException(ex, true);
            }
            TelemetryManager.TrackMetric("test metric", 100);
            TelemetryManager.TrackPageView("manualPageView");
        }
    }
}