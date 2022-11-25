using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class GradosCLS
    {
        public int id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Nombre debe contener entre {2} y {1} carácteres")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Range(1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar un profesor")]
        public int profesorid { get; set; }
        [DisplayName("Nombre del Profesor")]
        public string textoprofesor { get; set; }

    }
}
