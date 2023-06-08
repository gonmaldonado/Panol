using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;



namespace Logica
{
    public class Usuario
    {
        public static bool ValidarUsuario(int Legajo, string Contraseña)
        {
            return Datos.Usuario.ValidarUsuario(Legajo,Contraseña);
        }
        public static bool ValidarUsuario(int Legajo)
        {
            return Datos.Usuario.ValidarUsuario(Legajo);
        }
        public static Entidades.Usuario TraerUsuario(int Legajo)
        {
            return Datos.Usuario.TraerUsuario(Legajo);
        }
        public static void AltaUsuario (Entidades.Usuario pUsuario)
        {
            Datos.Usuario.AltaUsuario(pUsuario);
        }
        public static void ModificarUsuario(Entidades.Usuario pUsuario)
        {
            Datos.Usuario.ModificarUsuario(pUsuario);
        }
        public class Encrypt
        {
            public static string GetSHA256(string str)
            {
                SHA256 sha256 = SHA256Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }

        }

    }
}
