using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now + "; ");
            sb.Append(LoginValidation.CurrentUserName + "; ");
            sb.Append(LoginValidation.CurrentUserRole + "; ");
            sb.Append(activity).Append(Environment.NewLine);

            string activityLine = sb.ToString();
            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt"))
            {
                File.AppendAllText("test.txt", activityLine);
            }

        }
        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;

        }
       

    }
}
