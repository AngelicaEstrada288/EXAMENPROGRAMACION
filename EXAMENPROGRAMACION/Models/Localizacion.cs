using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EXAMENPROGRAMACION.Models
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(100)]
        public Double latitud { get; set; }
        [MaxLength(100)]
        public Double longitud { get; set; }
        [MaxLength(100)]
        public String descripcion_larga { get; set; }
        [MaxLength(100)]
        public String descripcion_corta { get; set; }

    }
}
