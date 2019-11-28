using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Model.WorkItem
{
    public class WorkItem
    {
        public WorkItem(string comment,double time,DateTime reportDate,string taskProgress,int taskId)
        {
            Comment = comment;
            Time = time;
            ReportDate = reportDate;
            TaskProgress = taskProgress;
            TaskId = taskId;
        }
        public string Comment { get;}
        public double Time { get; }
        public DateTime ReportDate { get; }
        public string TaskProgress { get; }
        public int TaskId { get; }
    }
}
