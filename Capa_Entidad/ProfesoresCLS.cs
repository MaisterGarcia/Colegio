using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ProfesoresCLS
    {
        public int id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Nombre debe contener entre {2} y {1} carácteres")]
        [DisplayName("Nombre del Profesor")]
        public string nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Los Apellidos es obligatorio")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Los Apellidos debe contener entre {2} y {1} carácteres")]
        [DisplayName("Apellidos del Profesor")]
        public string apellidos { get; set; }
        public int genero { get; set; }
        [DisplayName("Género")]
        public string textogenero { get; set; }
        public List<string> radios { get; set; }
    }
}
