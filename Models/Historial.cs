using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanTheater.Models
{
    public class Historial
    {
        public Historial() { }

        [Key]
        public int idObjeto { get; set; }

        [Required]
        public string nombreUsuario { get; set; }

        [Required]
        public string nombreObra { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public string sesion { get; set; }

        public int asiento { get; set; }
        public int idUsuario { get; set; }

    }
}
