using Capa_Entidad;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class GradosDAL : CadenaDAL
    {
        public async Task<List<GradosCLS>> listarGrados()
        {
            List<GradosCLS> lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    lista = (await cn.QueryAsync<GradosCLS>(@"SELECT t1.*,CONCAT(p.Nombre,' ',p.apellidos) AS textoprofesor FROM dbcolegio.grado as t1 inner join profesor as p on p.Id = ProfesorId")).ToList();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    cn.Close();
                }
            }
            return lista;
        }
        public async Task<GradosCLS> recuperarGrados(int id)
        {
            GradosCLS lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    lista = await cn.QueryFirstOrDefaultAsync<GradosCLS>(@"SELECT * FROM grado WHERE Id=@Id", new { id });
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    cn.Close();
                }
            }
            return lista;
        }
        public async Task<int> insertarGrados(GradosCLS oGradosCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"INSERT INTO grado (Nombre,ProfesorId) Values(@Nombre,@ProfesorId)", new { oGradosCLS.nombre, oGradosCLS.profesorid });
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    rpta = 0;
                    cn.Close();
                }
            }
            return 1;
        }
        public async Task<int> actualizarGrados(GradosCLS oGradosCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"UPDATE grado SET Nombre = @Nombre,ProfesorId = @ProfesorId WHERE Id=@Id", new { oGradosCLS.nombre, oGradosCLS.profesorid, oGradosCLS.id });
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    rpta = 0;
                    cn.Close();
                }
            }
            return 1;
        }
        public async Task<int> eliminarGrados(List<int> idgrado)
        {
            int rpta = 0;

            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    for (int i = 0; i < idgrado.Count; i++)
                    {
                        var id = idgrado[i];
                        await cn.ExecuteAsync(@"DELETE FROM grado WHERE Id = @id", new { id });
                    }
                    rpta = 1;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    Console.WriteLine(ex.Message);
                    cn.Close();
                }
            }
            return rpta;
        }
    }
}
