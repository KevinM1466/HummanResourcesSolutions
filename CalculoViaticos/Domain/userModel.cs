using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Common.cache;
using DataAccess;

namespace Domain
{
    public class userModel
    {
        userDao userDao = new userDao();

        //attributes
        private int userID;
        private string correo;
        private string contrasenia;
        private string confirmarContrasenia;
        private DateTime fechaModi;
        private int empleadoID;
        private string nombres;
        private string apellidos;
        private byte[] imagen;

        public userModel(int _userID, string _correo, string _contrasenia, string _confirmarContrasenia, DateTime _fechaModi, int _empleadoID, string _nombres, string _apellidos, byte[] _imagen)
        {
            this.userID = _userID;
            this.correo = _correo;
            this.contrasenia = _contrasenia;
            this.confirmarContrasenia = _confirmarContrasenia;
            this.fechaModi = _fechaModi;
            this.empleadoID = _empleadoID;
            this.nombres = _nombres;
            this.apellidos = _apellidos;
            this.imagen = _imagen;
        }

        public userModel()
        {

        }

        public string editProfile()
        {
            try
            {
                userDao.editProfile(userID, correo, contrasenia, confirmarContrasenia, fechaModi, empleadoID, nombres, apellidos, imagen);
                isLoginUser(correo, contrasenia);
                return "Su perfil se ha actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar los datos";
            }
        }

        public bool isLoginUser(string user, string password)
        {
            return userDao.Login(user, password);
        }

        public bool CargarAdmin()
        {
            return userDao.CargarAdmin();
        }
        public bool CargarJefe(string user, string pass)
        {
            return userDao.CargarJefe(user, pass);
        }

        public DataTable ActualizarPassword(string password, string confirmarPass, DateTime fechaModi, string correo)
        {
            DataTable tabla = new DataTable();
            tabla = userDao.ActualizarPassword(password, confirmarPass, fechaModi, correo);
            return tabla;
        }



        public void security(int id)
        {
            if (UserLoginCache.userID >= 1)
            {
                if (userDao.existsUser(UserLoginCache.userID) == true)
                {
                    //code
                }
            }
            if (UserLoginCache.userID == null || UserLoginCache.userID == 0)
            {
                //code
                var seguridad = userDao.MessageSecurity("noramartinez1466@gmail.com");
                MessageBox.Show(seguridad, "Error");
                Application.Exit();
            }
        }

        public string MessageRecursosHumanos(string userRequesting)
        {
            return userDao.MessageRecursosHumanos(userRequesting);
        }

        public string MessageJefeDirecto(string userRequesting)
        {
            return userDao.MessageJefeDirecto(userRequesting);
        }

        public string MessageEmpleado(string userRequesting)
        {
            return userDao.MensajeEmpleado(userRequesting);
        }

        public string recoverPassword(string userRequesting, string password)
        {
            return userDao.recoverPassword(userRequesting, password);
        }

        public void AnyMethod(FontAwesome.Sharp.IconButton solicitud, FontAwesome.Sharp.IconButton empleado, FontAwesome.Sharp.IconButton usuario, FontAwesome.Sharp.IconButton departamentos, FontAwesome.Sharp.IconButton puestos, FontAwesome.Sharp.IconButton Jefes, FontAwesome.Sharp.IconButton solicitudes, FontAwesome.Sharp.IconButton reportes )
        {
            userDao.AnyMethod(solicitud, empleado, usuario, departamentos, puestos, Jefes, solicitudes, reportes);
        }
    }
}
