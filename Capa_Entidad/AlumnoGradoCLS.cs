using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class AlumnoGradoCLS
    {
        public int id { get; set; }
        [Range(1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar un alumno")]
        public int alumnoid { get; set; }
        [Range(1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar un grado")]
        public int gradoid { get; set; }
        [DisplayName("Sección")]
        public string seccion { get; set; }
        [DisplayName("Nombre del Alumno")]
        public string textoalumno { get; set; }
        [DisplayName("Grado")]
        public string textogrado { get; set; }
        [DisplayName("Nombre del Profesor")]
        public string textoprofesor { get; set; }
    }
}
