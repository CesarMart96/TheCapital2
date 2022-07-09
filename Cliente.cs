using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TheCapitalBurguer.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Apellidos { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        public double? Telefono { get; set; }
    }
}