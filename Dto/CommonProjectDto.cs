using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Client.Dto
{
    public class CommonProjectDto:IEquatable<CommonProjectDto>
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public bool Equals(CommonProjectDto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ProjectId == other.ProjectId && string.Equals(ProjectName, other.ProjectName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CommonProjectDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ProjectId * 397) ^ (ProjectName != null ? ProjectName.GetHashCode() : 0);
            }
        }
    }
}
