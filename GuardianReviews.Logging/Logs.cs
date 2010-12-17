using System.Text;
using log4net;
using log4net.Config;

namespace GuardianReviews.Logging
{
    public class Logs
    {
        static Logs()
        {
            //set up logging
            XmlConfigurator.Configure();

        }
        public static ILog GetLog(string logName)
        {
            return LogManager.GetLogger(logName);
        }
        public static ILog OpenIdLog
        {
            get { return GetLog("OpenId"); }
        }
    }
}
