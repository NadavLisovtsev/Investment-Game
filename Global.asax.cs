using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace InvestmentGame
{
    public class Global : System.Web.HttpApplication
    {
        public static UniformDistributionGenerator scenarioNumGenerator = null;
        public static UniformDistributionGenerator trainingScenarioNumGenerator = null;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            scenarioNumGenerator = new UniformDistributionGenerator(1, int.Parse(ConfigurationManager.AppSettings["NumberOfScenarios"]));
            trainingScenarioNumGenerator = new UniformDistributionGenerator(1, int.Parse(ConfigurationManager.AppSettings["NumberOfScenarios"]));
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {

            Session["GM"] = new GameManager();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
