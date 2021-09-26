using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzLauncher.Classes
{
    class Database
    {
        public string insertToDatabase(List<KeyValuePair<string, string>> objectDB, string table)
        {
            string dataFields = null;
            string data = null;

            foreach (var item in objectDB)
            {
                dataFields += item.Key;
                dataFields += ", ";
                data += "@" + item.Key;
                data += ", ";
            }
            dataFields = dataFields.Remove(dataFields.Length - 2, 2);
            data = data.Remove(data.Length - 2, 2);

            string query = "INSERT INTO " + table + " (" + dataFields + ") VALUES (" + data + ")";

            SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
            SqlCommand objectDBcmd = new SqlCommand(query, conn);

            foreach (var item in objectDB)
            {
                objectDBcmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }

            conn.Open();
            objectDBcmd.ExecuteNonQuery();
            conn.Close();
            return query;

        }

        public ArrayList getDataFromDatabase(string sql)
        {
            string query = sql;
            SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
            SqlCommand objectDBcmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = objectDBcmd;

            DataTable tb = new DataTable();
            tb.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(tb);

            ArrayList arrayList = new ArrayList(tb.Rows.Count);
            foreach (DataRow row in tb.Rows)
            {
                arrayList.Add(row);
            }

            return arrayList;
        }

        public string updateToDatabase(List<KeyValuePair<string, string>> objectDB, string table, int id)
        {

            string dataFields = null;

            foreach (var item in objectDB)
            {
                dataFields += item.Key + " = @" + item.Key;
                dataFields += ", ";

            }
            dataFields = dataFields.Remove(dataFields.Length - 2, 2);
            string query = "UPDATE " + table + " SET " + dataFields + " WHERE id = @id";

            SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
            SqlCommand objectDBcmd = new SqlCommand(query, conn);
            objectDBcmd.Parameters.AddWithValue("@id", id);
            foreach (var item in objectDB)
            {
                objectDBcmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }

            conn.Open();
            objectDBcmd.ExecuteNonQuery();
            conn.Close();
            return query;

        }

        public string deleteFromDatabase(string table, int id)
        {
            string query = "DELETE FROM " + table + "  WHERE id = @id";
            SqlConnection conn = new SqlConnection(Constants.CONNECTION_STRING);
            SqlCommand credentialcmd = new SqlCommand(query, conn);
            credentialcmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            credentialcmd.ExecuteNonQuery();
            conn.Close();
            return query;
        }
    }


    class GzGame
    {
        public string igdbid { get; set; }
        public string name { get; set; }
        public string cover { get; set; }
        public string path { get; set; }
      
    }

    class User
    {
        public string username { get; set; }
        public string imagelocation { get; set; }

        public string imagebg { get; set; }

        public float bgopacity { get; set; }
    }
}
