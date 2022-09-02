using CatalogoEmpleadosCurso.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatalogoEmpleadosCurso.Models
{
    public class EmpleadosViewModel
    {

        public List<EmployeesGustavo> datos { get; set; }

        public List<PositionsGustavo> lista { get; set; }

        
        public int Id { get; set; }
        [Display(Name = "Fecha de Creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Cumpleaños { get; set; }
        public string RFC { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int SeleccionId { get; set; }
        public bool Eliminado { get; set; }
        public string Puesto { get; set; }

    }
}