using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.Entities
{
    public class Borrower : FullAuditedEntity<int>
    {
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int? StudentId { get; set; }
        public Student StudentFk { get; set; }
        public int BookId { get; set; }
        public Book BookFk { get; set; }

    }
}
