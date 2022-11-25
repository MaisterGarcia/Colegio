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
    public class AlumnoDAL : CadenaDAL
    {
        public async Task<List<AlumnoCLS>> listarAlumnos()
        {
            List<AlumnoCLS> lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    lista = (await cn.QueryAsync<AlumnoCLS>(@"SELECT Id,Nombre,Apellidos,Genero,FechaNacimiento,CASE WHEN Genero = 1 THEN  'Mujer' ELSE 'Hombre' END As TextoGenero FROM alumno")).ToList();
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
        public async Task<AlumnoCLS> recuperarAlumnos(int id)
        {
            AlumnoCLS lista = null;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    lista = await cn.QueryFirstOrDefaultAsync<AlumnoCLS>(@"SELECT Id,Nombre,Apellidos,Genero,FechaNacimiento FROM alumno WHERE Id=@Id", new { id });
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
        public async Task<int> insertarAlumno(AlumnoCLS oAlumnoCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"INSERT INTO  alumno(Nombre,Apellidos,Genero,FechaNacimiento) Values(@Nombre,@Apellidos,@Genero,@FechaNacimiento)", new { oAlumnoCLS.nombre, oAlumnoCLS.apellidos, oAlumnoCLS.genero, oAlumnoCLS.fechanacimiento });
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
        public async Task<int> actualizarAlumno(AlumnoCLS oAlumnoCLS)
        {
            int rpta = 0;
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    rpta = await cn.QuerySingleAsync<int>(@"UPDATE alumno SET Nombre = @Nombre,Apellidos = @Apellidos,Genero=@Genero,FechaNacimiento = @FechaNacimiento WHERE Id=@Id", new { oAlumnoCLS.nombre, oAlumnoCLS.apellidos, oAlumnoCLS.genero, oAlumnoCLS.fechanacimiento, oAlumnoCLS.id });
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
        public async Task<int> eliminarAlumno(List<int> idalumno)
        {
            int rpta = 0;

            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    for (int i = 0; i < idalumno.Count; i++)
                    {
                        var id = idalumno[i];
                        await cn.ExecuteAsync(@"DELETE FROM alumno WHERE Id = @id", new { id });
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
