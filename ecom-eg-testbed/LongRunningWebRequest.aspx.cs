using System;
using System.Web.UI;

namespace EcomEgTestBed
{
    public partial class LongRunningWebRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRunWithTimout_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTimeout.Text, out var seconds))
            {
                var started = DateTime.Now;
                var secondsTimespan = TimeSpan.FromSeconds(seconds);
                System.Threading.Thread.Sleep((int)secondsTimespan.TotalMilliseconds);
                lblFinished.Text = $"Processing started at {started.ToLongTimeString()} and completed after {seconds} seconds";
            }
        }
    }
}