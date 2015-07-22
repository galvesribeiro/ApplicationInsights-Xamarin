using System;
using Foundation;
using System.Collections.Generic;

namespace Microsoft.ApplicationInsights
{
    [Preserve(AllMembers = true)]
    public class TelemetryManager
    {
        public static void TrackEvent(string eventName)
        {
            MSAITelemetryManager.TrackEvent(eventName);
        }

        public static void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            MSAITelemetryManager.TrackEvent(eventName, properties.ToNSDictionary());
        }

        public static void TrackTrace(string message)
        {
            MSAITelemetryManager.TrackTrace(message);
        }

        public static void TrackTrace(string message, Dictionary<string, string> properties)
        {
            MSAITelemetryManager.TrackTrace(message, properties.ToNSDictionary());
        }

        public static void TrackMetric(string metricName, double value)
        {
            MSAITelemetryManager.TrackMetric(metricName, value);
        }

        public static void TrackMetric(string metricName, double value, Dictionary<string, string> properties)
        {
            MSAITelemetryManager.TrackMetric(metricName, value, properties.ToNSDictionary());
        }

        public static void TrackPageView(string pageName)
        {
            MSAITelemetryManager.TrackPageView(pageName);
        }

        public static void TrackPageView(string pageName, int duration)
        {
            MSAITelemetryManager.TrackPageView(pageName, duration);
        }

        public static void TrackPageView(string pageName, int duration, Dictionary<string, string> properties)
        {
            MSAITelemetryManager.TrackPageView(pageName, duration, properties.ToNSDictionary());
        }

        public static void TrackManagedException(Exception exception, bool handled)
        {
            if (exception != null)
            {
                string type = exception.GetType().Name;
                string stacktrace = exception.StackTrace;
                string message = exception.Message;
                MSAITelemetryManager.TrackManagedException(type, message, stacktrace, handled);
            }
        }
    }
}
