using System;
using System.Collections.Generic;

namespace Microsoft.ApplicationInsights
{
    public class TelemetryManager //: ITelemetryManager
    {
        public static void TrackEvent(string eventName)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackManagedException(Exception exception, bool handled)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackMetric(string metricName, double value)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackMetric(string metricName, double value, Dictionary<string, string> properties)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackPageView(string pageName)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackPageView(string pageName, int duration)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackPageView(string pageName, int duration, Dictionary<string, string> properties)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackTrace(string message)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }

        public static void TrackTrace(string message, Dictionary<string, string> properties)
        {
            throw new InvalidOperationException(PCL.BaitWithoutSwitchMessage);
        }
    }
}
