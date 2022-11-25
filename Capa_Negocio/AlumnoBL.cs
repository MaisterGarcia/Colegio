using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class AlumnoBL
    {
        public async Task<List<AlumnoCLS>> listarAlumnos()
        {
            AlumnoDAL oAlumnoDAL = new AlumnoDAL();
            return await oAlumnoDAL.listarAlumnos();
        }
        public async Task<AlumnoCLS> recuperarAlumnos(int id)
        {
            AlumnoDAL oAlumnoDAL = new AlumnoDAL();
            return await oAlumnoDAL.recuperarAlumnos(id);
        }
        public async Task<int> insertarAlumno(AlumnoCLS oAlumnoCLS)
        {
            AlumnoDAL oAlumnoDAL = new AlumnoDAL();
            return await oAlumnoDAL.insertarAlumno(oAlumnoCLS);
        }
        public async Task<int> actualizarAlumno(AlumnoCLS oAlumnoCLS)
        {
            AlumnoDAL oAlumnoDAL = new AlumnoDAL();
            return await oAlumnoDAL.actualizarAlumno(oAlumnoCLS);
        }
        public async Task<int> eliminarAlumno(List<int> idalumno)
        {
            AlumnoDAL oAlumnoDAL = new AlumnoDAL();
            return await oAlumnoDAL.eliminarAlumno(idalumno);
        }
    }
}
