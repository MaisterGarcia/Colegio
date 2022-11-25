using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Capa_Negocio
{
    public class AlumnoGradoBL
    {
        public async Task<List<AlumnoGradoCLS>> listarAlumnoGrado()
        {
            AlumnoGradoDAL oAlumnoGradoDAL = new AlumnoGradoDAL();
            return await oAlumnoGradoDAL.listarAlumnoGrados();
        }
        public async Task<AlumnoGradoCLS> recuperarAlumnoGrado(int id)
        {
            AlumnoGradoDAL oAlumnoGradoDAL = new AlumnoGradoDAL();
            return await oAlumnoGradoDAL.recuperarAlumnoGrados(id);
        }
        public async Task<int> insertarAlumnoGrado(AlumnoGradoCLS oAlumnoGradoCLS)
        {
            AlumnoGradoDAL oAlumnoGradoDAL = new AlumnoGradoDAL();
            return await oAlumnoGradoDAL.insertarAlumnoGrados(oAlumnoGradoCLS);
        }
        public async Task<int> actualizarAlumnoGrado(AlumnoGradoCLS oAlumnoGradoCLS)
        {
            AlumnoGradoDAL oAlumnoGradoDAL = new AlumnoGradoDAL();
            return await oAlumnoGradoDAL.actualizarAlumnoGrados(oAlumnoGradoCLS);
        }
        public async Task<int> eliminarAlumnoGrado(List<int> idalumnogrado)
        {
            AlumnoGradoDAL oAlumnoGradoDAL = new AlumnoGradoDAL();
            return await oAlumnoGradoDAL.eliminarAlumnoGrados(idalumnogrado);
        }
    }
}
