using LibrarySystemV8.AppService.Dto;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models.Borrowers
{
    public class BorrowerListViewModel
    {
        public List<BorrowerDto> Borrowers { get; set; }
    }
}
