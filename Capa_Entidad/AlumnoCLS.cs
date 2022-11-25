using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class AlumnoCLS
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Nombre debe contener entre {2} y {1} carácteres")]
        [DisplayName("Nombre Alumno")]
        public string nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Los Apellidos es obligatorio")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Los Apellidos debe contener entre {2} y {1} carácteres")]
        [DisplayName("Apellidos")]
        public string apellidos { get; set; }
        public int genero { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Fecha Nacimiento")]
        public DateTime fechanacimiento { get; set; }
        [DisplayName("Género")]
        public string textogenero { get; set; }
        public List<string> radios { get; set; }
        public string FullName
        {
            get
            {
                return nombre + " " + apellidos;
            }
        }

    }
}
