using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Language.Class
{
    class SQLClass
    {
        public static DataTable SQLDT(string query)
        {
            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter adapter;
                string connectionString = Properties.Settings.Default.SqlConnectionString;
                string sqlExpression = query;

                Trace.WriteLine("Connection sring = " + connectionString);
                Trace.WriteLine("Query = " + sqlExpression);

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(sqlExpression, connectionString);
                adapter.Fill(table);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
        }

        public static void ConvertDTtoDG(DataTable dataTable, DataGrid dataGrid)
        {
            dataGrid.DataContext = dataTable;
        }

        public static void NoReturnSQL(String sqlString)
        {
            try
            {
                string connectionString = Properties.Settings.Default.SqlConnectionString;
                string sqlExpression = sqlString;

                //Диагностика
                Trace.WriteLine("Connection sring = " + connectionString);
                Trace.WriteLine("Query = " + sqlExpression);

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery(); //Выполнение запроса без возращения данных
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static object[] MyGetArray(DataGrid dataGrid)
        {
            try
            {
                DataRowView row = dataGrid.SelectedItem as DataRowView;
                return row.Row.ItemArray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string MyGetItemArray(DataGrid dataGrid, int i)
        {
            try
            {
                object[] array = MyGetArray(dataGrid);
                return array[i].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string ArrayToValue(string[] valueName, string[] value)
        {
            List<string> valueСollection = new List<string>();
            for (int i = 0; i < valueName.Length; i++)
                valueСollection.Add(String.Concat(valueName[i], "=", value[i]));
            string resultStr = String.Join(", ", valueСollection);
            Trace.WriteLine(resultStr);
            return resultStr;
        }
    }
}
