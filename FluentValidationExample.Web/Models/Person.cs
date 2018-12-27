﻿using System.ComponentModel.DataAnnotations;

namespace FluentValidationExample.Web.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
    }
}