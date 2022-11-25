using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class GradosBL
    {
        public async Task<List<GradosCLS>> listarGrados()
        {
            GradosDAL oGradosDAL = new GradosDAL();
            return await oGradosDAL.listarGrados();
        }
        public async Task<GradosCLS> recuperarGrados(int id)
        {
            GradosDAL oGradosDAL = new GradosDAL();
            return await oGradosDAL.recuperarGrados(id);
        }
        public async Task<int> insertarGrados(GradosCLS oGradosCLS)
        {
            GradosDAL oGradosDAL = new GradosDAL();
            return await oGradosDAL.insertarGrados(oGradosCLS);
        }
        public async Task<int> actualizarGrados(GradosCLS oGradosCLS)
        {
            GradosDAL oGradosDAL = new GradosDAL();
            return await oGradosDAL.actualizarGrados(oGradosCLS);
        }
        public async Task<int> eliminarGrados(List<int> idgrado)
        {
            GradosDAL oGradosDAL = new GradosDAL();
            return await oGradosDAL.eliminarGrados(idgrado);
        }
    }
}
