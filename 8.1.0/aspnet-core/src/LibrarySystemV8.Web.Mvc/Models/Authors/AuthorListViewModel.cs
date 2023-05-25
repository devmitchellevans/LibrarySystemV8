using System.Collections.Generic;
using LibrarySystem.AppService.Dto;
using LibrarySystemV8.Roles.Dto;

namespace LibrarySystem.Web.Models.Authors
{
    public class AuthorListViewModel
    {
        public IReadOnlyList<AuthorDto> Authors { get; set; }
    }
}
