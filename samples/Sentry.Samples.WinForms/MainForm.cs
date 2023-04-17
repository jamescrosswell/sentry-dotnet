using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentry.Samples.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnThrow_Click(object sender, EventArgs e)
        {
            // The following unhandled exception will be captured and sent to Sentry.
            try
            {
                throw new Exception("Test exception");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            SentrySdk.CaptureMessage("Test message", SentryLevel.Debug);
        }
    }
}
