using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Dto
{
    public class CommonTaskDto
    {
        public CommonTaskDto(int taskId, string description, ETaskPriority taskPriority, DateTime endDate, double time)
        {
            TaskId = taskId;
            Description = description;
            TaskPriority = taskPriority;
            EndDate = endDate;
            Time = time;
        }
        public int TaskId { get; }
        public string Description { get; }
        public ETaskPriority TaskPriority { get; }
        public DateTime EndDate { get; }
        public double Time { get; }
    }
}
