using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Negocio
{
    public class ProfesoresBL
    {
        public async Task<List<ProfesoresCLS>> listarProfesores()
        {
            ProfesoresDAL oProfesoresDAL = new ProfesoresDAL();
            return await oProfesoresDAL.listarProfesores();
        }
        public async Task<ProfesoresCLS> recuperarProfesores(int id)
        {
            ProfesoresDAL oProfesoresDAL = new ProfesoresDAL();
            return await oProfesoresDAL.recuperarProfesores(id);
        }
        public async Task<int> insertarProfesores(ProfesoresCLS oProfesoresCLS)
        {
            ProfesoresDAL oProfesoresDAL = new ProfesoresDAL();
            return await oProfesoresDAL.insertarProfesores(oProfesoresCLS);
        }
        public async Task<int> actualizarProfesores(ProfesoresCLS oProfesoresCLS)
        {
            ProfesoresDAL oProfesoresDAL = new ProfesoresDAL();
            return await oProfesoresDAL.actualizarProfesores(oProfesoresCLS);
        }
        public async Task<int> eliminarProfesores(List<int> idprofesor)
        {
            ProfesoresDAL oProfesoresDAL = new ProfesoresDAL();
            return await oProfesoresDAL.eliminarProfesores(idprofesor);
        }
    }
}
