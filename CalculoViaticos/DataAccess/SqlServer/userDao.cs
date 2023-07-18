using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using Common.cache;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DataAccess
{
    public class userDao:ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public void editProfile(int userID, string correo, string contrasenia, string confirmarContrasenia, DateTime fechaModi, int empleadoID, string nombres, string apellidos, byte[] imagen)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditProfile";
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contrasenia", contrasenia);
                    command.Parameters.AddWithValue("@confirmarContrasenia", confirmarContrasenia);
                    command.Parameters.AddWithValue("@fechaModi", fechaModi);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "IniciarSesion";
                    command.Parameters.AddWithValue("@codigo", 0);
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@empleadoID", 0);
                    command.Parameters.AddWithValue("@correo", "");
                    command.Parameters.AddWithValue("@contrasenia", "");
                    command.Parameters.AddWithValue("@confirmarContra", "");
                    command.Parameters.AddWithValue("@fechaCreacion", null);
                    command.Parameters.AddWithValue("@fechaModi", null);
                    command.Parameters.AddWithValue("@imagen", null);
                    command.Parameters.AddWithValue("@accion", "Mostrar");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read()) {
                            UserLoginCache.userID = reader.GetInt32(0);
                            UserLoginCache.empleadoID = reader.GetInt32(1);
                            UserLoginCache.firstName = reader.GetString(2);
                            UserLoginCache.lastName = reader.GetString(3);
                            UserLoginCache.email = reader.GetString(4);
                            UserLoginCache.contrasenia = reader.GetString(5);
                            UserLoginCache.puesto = reader.GetString(6);
                            UserLoginCache.imagen = (byte[])reader.GetValue(7);
                            UserLoginCache.isJefe = reader.GetBoolean(8);
                        }
                        return true;
                    }
                    else return false;
                }
            }
        }

        public bool CargarAdmin()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "IniciarSesion";
                    command.Parameters.AddWithValue("@codigo", 0);
                    command.Parameters.AddWithValue("@empleadoID", 0);
                    command.Parameters.AddWithValue("@correo", "");
                    command.Parameters.AddWithValue("@contrasenia", "");
                    command.Parameters.AddWithValue("@confirmarContra", "");
                    command.Parameters.AddWithValue("@fechaCreacion", null);
                    command.Parameters.AddWithValue("@fechaModi", null);
                    command.Parameters.AddWithValue("@imagen", null);
                    command.Parameters.AddWithValue("@accion", "MostrarAdmin");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.correoAdmin = reader.GetString(4);
                            UserLoginCache.firmaAdmin = (byte[])reader.GetValue(8);
                        }
                        return true;
                    }
                    else return false;
                }
            }
        }
        
        public bool CargarJefe(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "IniciarSesion";
                    command.Parameters.AddWithValue("@codigo", 0);
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@empleadoID", 0);
                    command.Parameters.AddWithValue("@correo", "");
                    command.Parameters.AddWithValue("@contrasenia", "");
                    command.Parameters.AddWithValue("@confirmarContra", "");
                    command.Parameters.AddWithValue("@fechaCreacion", null);
                    command.Parameters.AddWithValue("@fechaModi", null);
                    command.Parameters.AddWithValue("@imagen", null);
                    command.Parameters.AddWithValue("@accion", "CargarJefe");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.jefeID = reader.GetInt32(9);
                        }
                        return true;
                    }
                    else return false;
                }
            }
        }

        public string recoverPassword(string userRequesting, string password)
        {            
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EnvioDeCorreos";
                    command.Parameters.AddWithValue("@correo", userRequesting);
                    command.Parameters.AddWithValue("@accion", "RecuperarContra");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(3) + " " + reader.GetString(4);
                        string userMail = reader.GetString(1);
                        string accountPassword = reader.GetString(2);
                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SISTEMA: Solicitud de recuperacion de contraseña",
                          body: "Hola " + userName + "\nsolicitaste recuperar tu contraseña.\n" +
                          "Por favor, revise su correo electrónico" + 
                          "\nContraseña temporal: " + password +
                          "\nAdvertencia, por favor cambie su contraseña una ves ingrese al sistema.",
                          recipientMail: new List<string> { userMail }
                          );
                        return "Hola " + userName + "\nsolicitaste recuperar tu contraseña.\n" +
                                "Por favor, revise su correo electrónico" +
                                "\nAdvertencia, por favor cambie su contraseña una ves ingrese al sistema.";
                    }
                    else
                        return "Lo sentimos, no tiene una cuenta con ese correo electronico";
                }
            }
        }

        public string MessageSecurity(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EnvioDeCorreos";
                    command.Parameters.AddWithValue("@correo", userRequesting);
                    command.Parameters.AddWithValue("@accion", "MensajeSeguridad");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(1) + " " + reader.GetString(2);
                        string userMail = reader.GetString(0);
                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SISTEMA: Intento de Hackeo",
                          body: "Hola " + userName + "\nAlguien ha intentado ingresar al sistema.\n" +
                          "Por favor, comuniquese con el equipo de seguridad",
                          recipientMail: new List<string> { userMail }
                          );
                        return "Intento de inicio sospechoso!";
                    }
                    else
                        return "Sorry, you do not have an account with that mail or username";
                }
            }
        }

        public string MessageRecursosHumanos(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EnvioDeCorreos";
                    command.Parameters.AddWithValue("@correo", userRequesting);
                    command.Parameters.AddWithValue("@accion", "MensajeRecursos");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(2) + " " + reader.GetString(3);
                        string userMail = reader.GetString(4);
                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SISTEMA: Mensaje de Solicitud",
                          body: "Hola " + userName + "\nun empleado ha realizado una solicitud en el sistema.\n" +
                          "Por favor, revisela lo mas pronto posible",
                          recipientMail: new List<string> { userMail }
                          );
                        return "¡Realizacion de solicitud de permisos y vacaciones!";
                    }
                    else
                        return "Lo siento hubo un problema en el sistema";
                }
            }
        }

        public string MessageJefeDirecto(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EnvioDeCorreos";
                    command.Parameters.AddWithValue("@correo", userRequesting);
                    command.Parameters.AddWithValue("@accion", "MensajeJefeDirecto");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(2) + " " + reader.GetString(3);
                        string userMail = reader.GetString(4);
                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SISTEMA: Mensaje de Respuesta a una Solicitud",
                          body: "Hola " + userName + "\nun empleado de su area ha realizado una solicitud en el sistema.\n" +
                          "Por favor, revisela lo mas pronto posible",
                          recipientMail: new List<string> { userMail }
                          );
                        return "¡Realizacion de solicitud de permisos y vacaciones!";
                    }
                    else
                        return "Lo siento hubo un problema en el sistema";
                }
            }
        }

        public string MensajeEmpleado(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EnvioDeCorreos";
                    command.Parameters.AddWithValue("@correo", userRequesting);
                    command.Parameters.AddWithValue("@accion", "MensajeEmpleado");
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(1);
                        string userMail = reader.GetString(2);
                        var mailService = new MailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SISTEMA: Mensaje de Respuesta a una Solicitud",
                          body: "Hola " + userName + "\ntu solicitud ha sido aprovada por tu jefe de departamento.\n" +
                          "Por favor, revisela lo mas pronto posible, si aun no la puede visualizar\n " +
                          "comuniquese con su jefe inmediato para que pueda solucionar",
                          recipientMail: new List<string> { userMail }
                          );
                        return "¡Realizacion de solicitud de permisos y vacaciones!";
                    }
                    else
                        return "Lo siento hubo un problema en el sistema";
                }
            }
        }

        public bool existsUser(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT *
                                        FROM users
                                        WHERE userID = @userID";
                    command.Parameters.AddWithValue("@userID", id);
                    command.CommandType = CommandType.Text;
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Dispose();
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public DataTable ActualizarPassword(string password, string confirmarPass, DateTime fechaModi, string correo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "PasswordTemp";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@confirmarPass", confirmarPass);
                    command.Parameters.AddWithValue("@fechaModi", fechaModi);
                    command.Parameters.AddWithValue("@correo", correo);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public void AnyMethod(FontAwesome.Sharp.IconButton solicitud, FontAwesome.Sharp.IconButton empleado, FontAwesome.Sharp.IconButton usuario, FontAwesome.Sharp.IconButton departamentos, FontAwesome.Sharp.IconButton puestos, FontAwesome.Sharp.IconButton Jefes, FontAwesome.Sharp.IconButton solicitudes)
        {
            if (UserLoginCache.puesto == Cargos.Administrador)
            {
                solicitud.Visible = true;
                empleado.Visible = true;
                usuario.Visible = true;
                departamentos.Visible = true;
                puestos.Visible = true;
                Jefes.Visible = true;
                solicitudes.Visible = true;
            }
            else if (UserLoginCache.isJefe == Cargos.Jefe)
            {
                solicitud.Visible = true;
                empleado.Visible = false;
                usuario.Visible = false;
                departamentos.Visible = false;
                puestos.Visible = false;
                Jefes.Visible = false;
                solicitudes.Visible = true;
            } else
            {
                solicitud.Visible = true;
                empleado.Visible = false;
                usuario.Visible = false;
                departamentos.Visible = false;
                puestos.Visible = false;
                Jefes.Visible = false;
                solicitudes.Visible = true;
            }
        }
    }
}
