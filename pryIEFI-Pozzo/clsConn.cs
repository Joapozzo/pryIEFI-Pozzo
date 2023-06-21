using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace pryIEFI_Pozzo
{
    internal class clsConn
    {
        OleDbConnection connDb = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb");
        OleDbCommand commandDb = new OleDbCommand();
        OleDbDataReader readerDb;

 
        public void cargarPais(string nombrePais)
        {
            connDb.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb";

            commandDb.Connection = connDb;
            commandDb.CommandType = CommandType.Text;
            commandDb.CommandText = "SELECT NOMBRE_PAIS FROM PAISES WHERE NOMBRE_PAIS = ?";
            commandDb.Parameters.AddWithValue("@Pais", nombrePais);

            commandDb.Connection.Open();
            readerDb = commandDb.ExecuteReader();

            if (readerDb.HasRows)
            {
                MessageBox.Show("Pais existente");
                commandDb.Connection.Close();
                return;
            }

            MessageBox.Show("Pais agregado con exito");
            readerDb.Close();

            commandDb.CommandText = "INSERT INTO PAISES (NOMBRE_PAIS) VALUES (?)";
            commandDb.Parameters.AddWithValue("@Pais", nombrePais.Trim());

            commandDb.ExecuteNonQuery();
            commandDb.Connection.Close();
        }

        public void cargarCombo(ComboBox cmbPaises)
        {
            cmbPaises.Items.Clear();
            commandDb.Connection = connDb;
            commandDb.CommandType = CommandType.TableDirect;
            commandDb.CommandText = "PAISES";
            commandDb.Connection.Open();
            readerDb = commandDb.ExecuteReader();

            while (readerDb.Read())
            {
                cmbPaises.Items.Add(readerDb[1]);
            }

            commandDb.Connection.Close();
        }

        public void agregarSocio(string nombre, string apellido, string pais, int edad, string sexo, decimal importe, int puntaje)
        {
            connDb.Open();

            OleDbCommand commandInsert = new OleDbCommand();
            commandInsert.Connection = connDb;
            commandInsert.CommandType = CommandType.Text;
            commandInsert.CommandText = "INSERT INTO SOCIOS (Nombre, Apellido, Pais, Edad, Sexo, Importe, Puntaje) VALUES (?, ?, ?, ?, ?, ?, ?)";
            commandInsert.Parameters.AddWithValue("@Nombre", nombre);
            commandInsert.Parameters.AddWithValue("@Apellido", apellido);
            commandInsert.Parameters.AddWithValue("@Pais", pais);
            commandInsert.Parameters.AddWithValue("@Edad", edad);
            commandInsert.Parameters.AddWithValue("@Sexo", sexo);
            commandInsert.Parameters.AddWithValue("@Importe", importe);
            commandInsert.Parameters.AddWithValue("@Puntaje", puntaje);

            commandInsert.ExecuteNonQuery();

            connDb.Close();
        }


    }
}
