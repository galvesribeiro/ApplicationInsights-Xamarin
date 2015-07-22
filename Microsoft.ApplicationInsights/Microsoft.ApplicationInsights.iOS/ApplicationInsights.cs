using System;
using Foundation;
using System.Runtime.InteropServices;

namespace Microsoft.ApplicationInsights
{
    [Preserve(AllMembers = true)]
    public class ApplicationInsights 
    {

        [DllImport("libc")]
        private static extern int sigaction(Signal sig, IntPtr act, IntPtr oact);

        enum Signal
        {
            SIGBUS = 10,
            SIGSEGV = 11
        }

        private static bool _crashManagerDisabled = false;
        
        public static void Init()
        {
            var forceLoad = new ApplicationInsights();
        }

        public static void Setup(string instrumentationKey)
        {
            MSAIApplicationInsights.Setup(instrumentationKey);
            MSAIApplicationInsights.SetAutoSessionManagementDisabled(false);
        }        

        public static void Start()
        {
            IntPtr sigbus = Marshal.AllocHGlobal(512);
            IntPtr sigsegv = Marshal.AllocHGlobal(512);

            // Store Mono SIGSEGV and SIGBUS handlers
            sigaction(Signal.SIGBUS, IntPtr.Zero, sigbus);
            sigaction(Signal.SIGSEGV, IntPtr.Zero, sigsegv);

            MSAIApplicationInsights.Start();
            registerUnhandledExceptionHandler();
            sigaction(Signal.SIGBUS, sigbus, IntPtr.Zero);
            sigaction(Signal.SIGSEGV, sigsegv, IntPtr.Zero);
        }

        public static string GetServerUrl()
        {
            return MSAIApplicationInsights.SharedInstance.ServerURL;
        }

        public static void SetServerUrl(string serverUrl)
        {
            MSAIApplicationInsights.SharedInstance.ServerURL = serverUrl;
        }

        public static void SetCrashManagerDisabled(bool crashManagerDisabled)
        {
            _crashManagerDisabled = crashManagerDisabled;
            MSAIApplicationInsights.SetCrashManagerDisabled(crashManagerDisabled);
        }

        public static void SetTelemetryManagerDisabled(bool telemetryManagerDisabled)
        {
            MSAIApplicationInsights.SetTelemetryManagerDisabled(telemetryManagerDisabled);
        }

        public static void SetAutoPageViewTrackingDisabled(bool autoPageViewTrackingDisabled)
        {
            MSAIApplicationInsights.SetAutoPageViewTrackingDisabled(autoPageViewTrackingDisabled);
        }

        public static void SetAutoSessionManagementDisabled(bool autoSessionManagementDisabled)
        {
            MSAIApplicationInsights.SetAutoSessionManagementDisabled(autoSessionManagementDisabled);
        }

        public static void SetUserId(string userId)
        {
            MSAIApplicationInsights.SetUserId(userId);
        }

        public static void StartNewSession()
        {
            MSAIApplicationInsights.StartNewSession();
        }

        public static void SetSessionExpirationTime(int appBackgroundTime)
        {
            MSAIApplicationInsights.SetAppBackgroundTimeBeforeSessionExpires((nuint)appBackgroundTime);
        }

        public static void RenewSessionWithId(string sessionId)
        {
            MSAIApplicationInsights.RenewSessionWithId(sessionId);
        }

        public static bool GetDebugLogEnabled()
        {
            return MSAIApplicationInsights.SharedInstance.DebugLogEnabled;
        }

        public static void SetDebugLogEnabled(bool debugLogEnabled)
        {
            MSAIApplicationInsights.SharedInstance.DebugLogEnabled = debugLogEnabled;
        }

        private static void registerUnhandledExceptionHandler()
        {
            if (!_crashManagerDisabled)
            {
                System.AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            }
        }

        public static void OnUnhandledException(object e, System.UnhandledExceptionEventArgs args)
        {
            Exception managedException = (Exception)args.ExceptionObject;
            Console.WriteLine(managedException.Source);
            if (managedException != null && !managedException.Source.Equals("Xamarin.iOS"))
            {
                TelemetryManager.TrackManagedException(managedException, false);
            }
        }
    }
}
