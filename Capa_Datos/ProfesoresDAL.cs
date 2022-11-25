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
    public class ProfesoresDAL : CadenaDAL
    {
        public async Task<List<ProfesoresCLS>> listarProfesores()
        {
            List<ProfesoresCLS> lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    lista = (await cn.QueryAsync<ProfesoresCLS>(@"SELECT Id,Nombre,Apellidos,Genero,CASE WHEN Genero = 1 THEN  'Mujer' ELSE 'Hombre' END As TextoGenero FROM profesor")).ToList();
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
        public async Task<ProfesoresCLS> recuperarProfesores(int id)
        {
            ProfesoresCLS lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    lista = await cn.QueryFirstOrDefaultAsync<ProfesoresCLS>(@"SELECT Id,Nombre,Apellidos,Genero FROM profesor WHERE Id=@Id", new { id });
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
        public async Task<int> insertarProfesores(ProfesoresCLS oProfesoresCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"INSERT INTO  profesor(Nombre,Apellidos,Genero) Values(@Nombre,@Apellidos,@Genero)", new { oProfesoresCLS.nombre, oProfesoresCLS.apellidos, oProfesoresCLS.genero });
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
        public async Task<int> actualizarProfesores(ProfesoresCLS oProfesoresCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"UPDATE profesor SET Nombre = @Nombre,Apellidos = @Apellidos,Genero=@Genero WHERE Id=@Id", new { oProfesoresCLS.nombre, oProfesoresCLS.apellidos, oProfesoresCLS.genero, oProfesoresCLS.id });
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
        public async Task<int> eliminarProfesores(List<int> idprofesor)
        {
            int rpta = 0;

            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    for (int i = 0; i < idprofesor.Count; i++)
                    {
                        var id = idprofesor[i];
                        await cn.ExecuteAsync(@"DELETE FROM profesor WHERE Id = @id", new { id });
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
