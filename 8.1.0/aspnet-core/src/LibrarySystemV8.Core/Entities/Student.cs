using Abp.Domain.Entities.Auditing;
using LibrarySystemV8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.Entities
{
    public class Student : FullAuditedEntity<int>
    {
        public string StudentName { get; set; }
        public string StudentContactNumber { get; set; }
        public string StudentEmail{ get; set; }
        public int DepartmentId { get; set; }

        public Department DepartmentFk { get; set; }
    }
}
