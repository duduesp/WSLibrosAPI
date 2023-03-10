using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLibros.Validations;
using System;

namespace WebApiLibros.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El Nombre es campo obligatorio")]
        [PrimeraLetraMayusculaAtributte]
        [Column(TypeName = "varchar(50)")]


        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Range(18, 110, ErrorMessage ="Solo se acepta edades entre 18 y 110 años.")]
        public int? Edad { get; set; }


        [Required]
        [FechaMayorAtributte]
        public DateTime FechaDeNacimiento { get; set; }

        public List <Libro> Libros { get; set; }
    }
}
