using System;

using Android.App;
using Android.Runtime;

namespace Microsoft.ApplicationInsights
{
    [Preserve(AllMembers = true)]
    public class ApplicationInsights  : Java.Lang.Object
    {
        private static bool _crashManagerDisabled = false;

        public static void Setup(string instrumentationKey)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Setup(Application.Context, (Application)Application.Context, instrumentationKey);
        }

        public static void Start()
        {
            registerUnhandledExceptionHandler();
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Start();
        }

        public string GetServerUrl()
        {
            return Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Config.EndpointUrl;
        }

        public static void SetServerUrl(string serverUrl)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Config.EndpointUrl = serverUrl;
        }

        public static void SetCrashManagerDisabled(bool crashManagerDisabled)
        {
            _crashManagerDisabled = crashManagerDisabled;
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetExceptionTrackingDisabled(crashManagerDisabled);
        }

        public static void SetTelemetryManagerDisabled(bool telemetryManagerDisabled)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetTelemetryDisabled(telemetryManagerDisabled);
        }

        public static void SetAutoPageViewTrackingDisabled(bool autoPageViewTrackingDisabled)
        {
            if (autoPageViewTrackingDisabled)
            {
                Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DisableAutoPageViewTracking();
            }
            else
            {
                Com.Microsoft.Applicationinsights.Library.ApplicationInsights.EnableAutoPageViewTracking();
            }
        }

        public static void SetAutoSessionManagementDisabled(bool autoSessionManagementDisabled)
        {
            if (autoSessionManagementDisabled)
            {
                Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DisableAutoSessionManagement();
            }
            else
            {
                Com.Microsoft.Applicationinsights.Library.ApplicationInsights.EnableAutoSessionManagement();
            }
        }

        public static void SetUserId(string userId)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetUserId(userId);
        }

        public static void StartNewSession()
        {
        }

        public static void SetSessionExpirationTime(int appBackgroundTime)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Config.SessionIntervalMs = appBackgroundTime;
        }

        public static void RenewSessionWithId(string sessionId)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.RenewSession(sessionId);
        }

        public bool GetDebugLogEnabled()
        {
            return Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DeveloperMode;
        }

        public static void SetDebugLogEnabled(bool debugLogEnabled)
        {
            Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DeveloperMode = debugLogEnabled;
        }

        private static void registerUnhandledExceptionHandler()
        {
            //Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetExceptionTrackingDisabled(true);
            if (!_crashManagerDisabled)
            {
                AndroidEnvironment.UnhandledExceptionRaiser += OnUnhandledExceptionRaiser;
            }
        }

        public static void OnUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            Exception managedException = (Exception)e.Exception;
            if (managedException != null)
            {
                TelemetryManager.TrackManagedException(managedException, false);
            }
        }
    }
}