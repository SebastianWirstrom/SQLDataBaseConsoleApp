﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
    }
}
