﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("VoucherCode")]
    public class VoucherCode
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Dieukien { get; set; }
    }
}