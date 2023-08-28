using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class UsuariosD
    {
        private UsuariosDA usuarios = new UsuariosDA();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.Mostrar();
            return tabla;
        }

        public DataTable Insertar(int empleadoID, string correo, string contrasenia, string confirmarContra)
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.Insertar(empleadoID, correo, contrasenia, confirmarContra);
            return tabla;
        }

        public DataTable Actualizar(int codigo, int empleadoID, string correo, string contrasenia, string confirmarContra)
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.Actualizar(codigo, empleadoID, correo, contrasenia, confirmarContra);
            return tabla;
        }

        public DataTable Eliminar(int codigo, string nombreDepartamento)
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.Eliminar(codigo, nombreDepartamento);
            return tabla;
        }
    }
}
