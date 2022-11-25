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
    public class AlumnoGradoDAL : CadenaDAL
    {
        public async Task<List<AlumnoGradoCLS>> listarAlumnoGrados()
        {
            List<AlumnoGradoCLS> lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    lista = (await cn.QueryAsync<AlumnoGradoCLS>(@"SELECT t1.*,CONCAT(a.Nombre,' ',a.apellidos) AS textoalumno,g.nombre as textogrado,CONCAT(p.Nombre,' ',p.apellidos) AS textoprofesor FROM dbcolegio.alumnogrado as t1 inner join alumno a on a.Id = t1.AlumnoId INNER JOIN grado g on g.Id = t1.GradoId INNER JOIN profesor as p on p.Id = g.ProfesorId;")).ToList();
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
        public async Task<AlumnoGradoCLS> recuperarAlumnoGrados(int id)
        {
            AlumnoGradoCLS lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    lista = await cn.QueryFirstOrDefaultAsync<AlumnoGradoCLS>(@"SELECT * FROM alumnogrado WHERE Id=@Id", new { id });
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
        public async Task<int> insertarAlumnoGrados(AlumnoGradoCLS oAlumnoGradoCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"INSERT INTO alumnogrado (AlumnoId,GradoId,Seccion) Values(@AlumnoId,@GradoId,@Seccion)", new { oAlumnoGradoCLS.alumnoid, oAlumnoGradoCLS.gradoid, oAlumnoGradoCLS.seccion });
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
        public async Task<int> actualizarAlumnoGrados(AlumnoGradoCLS oAlumnoGradoCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"UPDATE alumnogrado SET AlumnoId= @AlumnoId,GradoId = @GradoId,Seccion = @Seccion WHERE Id=@Id", new { oAlumnoGradoCLS.alumnoid, oAlumnoGradoCLS.gradoid, oAlumnoGradoCLS.seccion, oAlumnoGradoCLS.id });
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
        public async Task<int> eliminarAlumnoGrados(List<int> idalumnogrado)
        {
            int rpta = 0;

            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    for (int i = 0; i < idalumnogrado.Count; i++)
                    {
                        var id = idalumnogrado[i];
                        await cn.ExecuteAsync(@"DELETE FROM alumnogrado WHERE Id = @id", new { id });
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
