using System;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Routing;

namespace EcomEgTestBed
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private const bool TenantInitializing = false;

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_BeginRequest");


            // ReadInfraCatalog.ReadItemsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            
            //throw new InvalidOperationException();

            if (TenantInitializing)
            {
                try
                {
                    var httpResponse = HttpContext.Current.Response;
                    httpResponse.StatusCode = (int)HttpStatusCode.Accepted;
                    httpResponse.Write($"Initializing tenant");

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Application_BeginRequest EXCEPTION " + ex.Message);
                }
            }
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var x = HttpContext.Current;
            Debug.WriteLine("Application_Error");
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Debug.WriteLine("Session_Start");
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Debug.WriteLine("Session_End");

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_EndRequest");
        }

        protected void Application_End(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_End");
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AcquireRequestState");
        }

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PostRequestHandlerExecute");
        }
    }
}