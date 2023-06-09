﻿using LibrarySystem.AppService.Dto;
using LibrarySystemV8.AppService.Dto;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models.Books
{
    public class CreateOrEditBookViewModel
    { 
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }
        public bool? IsBorrowed { get; set; }
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
        public List<AuthorDto> Authors{ get; set; }
        public List<BookCategoryDto> BookCategories{ get; set; }
    }
}
