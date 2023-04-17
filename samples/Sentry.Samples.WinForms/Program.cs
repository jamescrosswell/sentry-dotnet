using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sentry;

namespace Sentry.Samples.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Add this so Sentry can catch unhandled exceptions
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            // Configure the options for Sentry
            var sentryOptions = new SentryOptions
            {
                // Tells which project in Sentry to send events to:
                Dsn = "https://eb18e953812b41c3aeb042e666fd3b5c@o447951.ingest.sentry.io/5428537",

                // When configuring for the first time, to see what the SDK is doing:
                Debug = true,

                // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                TracesSampleRate = 1.0,

                // Enable Global Mode since this is a client app
                IsGlobalModeEnabled = true,

                //TODO: any other options you need go here
            };

            // Initialize Sentry and run the main form of the application
            using (SentrySdk.Init(sentryOptions))
            {
                SentrySdk.StartSession();
                try
                {
                    Application.Run(new MainForm());
                }
                finally
                { 
                    SentrySdk.EndSession();
                }
            }
        }
    }
}
