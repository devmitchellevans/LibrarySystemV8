﻿using Abp.Application.Services.Dto;
using System;

namespace LibrarySystem.AppService.Dto
{
    //custom PagedResultRequestDto
    public class PagedStudentResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; } 
        public bool? IsActive { get; set; }
    }
}
