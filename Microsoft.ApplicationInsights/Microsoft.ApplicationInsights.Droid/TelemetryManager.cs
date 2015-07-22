using Com.Microsoft.Applicationinsights.Library;
using System;
using System.Collections.Generic;

namespace Microsoft.ApplicationInsights
{
    public class TelemetryManager
    {
        public static void TrackEvent(string eventName)
        {
            TelemetryClient.Instance.TrackEvent(eventName);
        }

        public static void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            TelemetryClient.Instance.TrackEvent(eventName, properties);
        }

        public static void TrackTrace(string message)
        {
            TelemetryClient.Instance.TrackTrace(message);
        }

        public static void TrackTrace(string message, Dictionary<string, string> properties)
        {
            TelemetryClient.Instance.TrackTrace(message, properties);
        }

        public static void TrackMetric(string metricName, double value)
        {
            TelemetryClient.Instance.TrackMetric(metricName, value);
        }

        public static void TrackMetric(string metricName, double value, Dictionary<string, string> properties)
        {
            TelemetryClient.Instance.TrackMetric(metricName, value);
        }

        public static void TrackPageView(string pageName)
        {
            TelemetryClient.Instance.TrackPageView(pageName);
        }

        public static void TrackPageView(string pageName, int duration)
        {
            TelemetryClient.Instance.TrackPageView(pageName);
        }

        public static void TrackPageView(string pageName, int duration, Dictionary<string, string> properties)
        {
            TelemetryClient.Instance.TrackPageView(pageName, properties);
        }

        public static void TrackManagedException(Exception exception, bool handled)
        {
            if (exception != null)
            {
                string type = exception.GetType().Name;
                string stacktrace = exception.StackTrace;
                string message = exception.Message;
                TelemetryClient.Instance.TrackManagedException(type, message, stacktrace, handled);
            }
        }
    }
}
