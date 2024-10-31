using DAO.INTERFAZ;
using DAO.MODELADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace DAO.IMPLEMENTACION
{
    public class UsuarioImpl : BaseImpl, IUsuario
    {

        public int Insert(Usuario t)
        {
            query = @"INSERT INTO usuario(ci, nombres, primerApellido, segundoApellido, fechaNacimiento, 
                             sexo, rol, nombreUsuario, contrasenia, idUsuario) 
                      VALUES(@ci, @nombres, @primerApellido, @segundoApellido, @fechaNacimiento, 
                             @sexo, @rol, @nombreUsuario, md5(@contrasenia), 1);";

            MySqlCommand command = CreateBasicCommand(this.query);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@nombres", t.Nombres);
            command.Parameters.AddWithValue("@primerApellido", t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.SegundoApellido);
            command.Parameters.AddWithValue("@fechaNacimiento", t.FechaNacimiento);
            command.Parameters.AddWithValue("@sexo", t.Sexo);
            command.Parameters.AddWithValue("@rol", t.Rol);
            command.Parameters.AddWithValue("@nombreUsuario", t.NombreUsuario);
            command.Parameters.AddWithValue("@contrasenia", t.Password);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario Get(byte id)
        {
            Usuario t = null;

            this.query = @"SELECT id, ci, nombres, primerApellido, segundoApellido, fechaNacimiento, sexo, rol, nombreUsuario, 
                                contrasenia, estado, fechaRegistro, IFNULL(fechaActualizacion,CURRENT_TIMESTAMP)
                   FROM usuario
                   WHERE id=@id;";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Usuario
                    {
                        Id = byte.Parse(table.Rows[0][0].ToString()),
                        Ci = table.Rows[0][1].ToString(),
                        Nombres = table.Rows[0][2].ToString(),
                        PrimerApellido = table.Rows[0][3].ToString(),
                        SegundoApellido = table.Rows[0][4].ToString(),
                        FechaNacimiento = DateTime.Parse(table.Rows[0][5].ToString()),
                        Sexo = table.Rows[0][6].ToString(),
                        Rol = table.Rows[0][7].ToString(),
                        NombreUsuario = table.Rows[0][8].ToString(),
                        Password = table.Rows[0][9].ToString(),
                        Estado = byte.Parse(table.Rows[0][10].ToString()),
                        FechaRegistro = DateTime.Parse(table.Rows[0][11].ToString()),
                        FechaActualizacion = DateTime.Parse(table.Rows[0][12].ToString()),

                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public DataTable Login(string nombreUsuario, string contrasenia)
        {
            query = @"SELECT id, rol, nombreUsuario
                    FROM usuario
                    WHERE estado=1
                    AND nombreUsuario=@nombreUsuario
                    AND contrasenia = MD5(@contrasenia)";


            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            command.Parameters.AddWithValue("@contrasenia", contrasenia).MySqlDbType = MySqlDbType.VarChar;
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(Usuario t)
        {
            query = @"UPDATE usuario SET estado=0, fechaActualizacion=CURRENT_TIMESTAMP
                      WHERE id=@id;";

            MySqlCommand command = CreateBasicCommand(this.query);

            command.Parameters.AddWithValue("@id", t.Id);
            return ExecuteBasicCommand(command);
        }
        public int Update(Usuario t)
        {
            query = @"UPDATE usuario SET ci = @ci, nombres = @nombres, primerApellido = @primerApellido, segundoApellido = @segundoApellido,
		                     fechaNacimiento = @fechaNacimiento, sexo = @sexo, rol = @rol, fechaActualizacion = CURRENT_TIMESTAMP
                      WHERE id = @id;";

            MySqlCommand command = CreateBasicCommand(this.query);

            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@nombres", t.Nombres);
            command.Parameters.AddWithValue("@primerApellido", t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.SegundoApellido);
            command.Parameters.AddWithValue("@fechaNacimiento", t.FechaNacimiento);
            command.Parameters.AddWithValue("@sexo", t.Sexo);
            command.Parameters.AddWithValue("@rol", t.Rol);


            return ExecuteBasicCommand(command);
        }

        public DataTable Select()
        {
            query = @"SELECT id AS ID, ci AS CI, nombres AS NOMBRES, primerApellido AS 'APELLIDO PATERNO', IFNULL(segundoApellido, 'S/N')AS 'APELLIDO MATERNO', fechaNacimiento AS 'FECHA DE NACIENTO', 
                             sexo AS SEXO, rol AS ROL
                      FROM usuario
                      where estado = 1
                      ORDER BY 2;";

            MySqlCommand command = CreateBasicCommand(this.query);
            return ExecuteDataTableCommand(command);
        }

        public int CambiarContraseña(Usuario t)
        {
            query = @"UPDATE usuario SET contrasenia= md5(@contrasenia)
                      WHERE id = @id;";
            MySqlCommand command = CreateBasicCommand(this.query);

            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@contrasenia", t.Password).MySqlDbType = MySqlDbType.VarChar;
            return ExecuteBasicCommand(command);
        }

        public int ValidarUsuario(Usuario t)
        {
            query = @"SELECT * FROM usuario
                      WHERE nombreUsuario = @nombreUsuario;";
            MySqlCommand command = CreateBasicCommand(this.query);

            command.Parameters.AddWithValue("@nombreUsuario", t.NombreUsuario);
            return ExecuteBasicCommand(command);
        }
    }
}
