using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Protsyuk.IS63.KR
{
    class Program
    {

        /// <summary>
        /// рядок підключення до БД
        /// </summary>
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ProtsyukDB;Integrated Security=True";
        /// <summary>
        /// Відкриття з`єднання з БД
        /// </summary>
        static public SqlConnection connection = null;
        static public void OpenConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
       /// <summary>
       /// Закриття з`єднання
       /// </summary>
        static public void CloseConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Видалення запису з БД
        /// </summary>
        static public void Delete()
        {
            int number;
            string table, pole, val, sqlExpression;
            OpenConnection(connectionString);
            Console.WriteLine("Виберiть таблицю з якої видаляти (PLANET, SATELLITE, GALAXY)");
            table = Console.ReadLine();
            string sql = "SELECT * FROM "+ table;
            ///Використання адаптера даних
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ///Представляє на стороні клієнта зовнішні дані
            DataTable dt = ds.Tables[0];
            foreach (DataColumn column in dt.Columns)
                Console.Write("{0,-18}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }
            Console.Write("\nВведiть поле, по якому будемо видаляти рядок: ");
            pole = Console.ReadLine();
            Console.Write("\nВведiть значення, по якому будемо видаляти рядок: ");
            val = Console.ReadLine();
            if (pole == "ID")
            {
                int val1 = Convert.ToInt32(val);
                sqlExpression = "DELETE FROM "+table+" WHERE " + pole + "=" + val1;
            }
            else sqlExpression = "DELETE FROM "+table+" WHERE " + pole + "='" + val + "'";
            SqlCommand command1 = new SqlCommand(sqlExpression, connection);
            try
            {
                number = command1.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Exception error = new Exception("Помилка виконання!", ex);
                throw error;
            }            
            Console.Write("Натиснiть Enter для виходу");
            Console.ReadLine();            
        }
        /// <summary>
        /// Оновлення таблиці
        /// </summary>
        static public void Update()
        {
            int number;
            string table, pole, val, sqlExpression;
            OpenConnection(connectionString);
            Console.WriteLine("Виберiть таблицю з якої видаляти (PLANET, SATELLITE, GALAXY)");
            table = Console.ReadLine();
            string sql = "SELECT * FROM " + table;
            ///Використання адаптера даних
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ///Представляє на стороні клієнта зовнішні дані
            DataTable dt = ds.Tables[0];
            foreach (DataColumn column in dt.Columns)
                Console.Write("{0,-18}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }
            Console.Write("Введiть ID, по якому будемо змiнювати значення: ");
            int help = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведiть поле, яке будемо змiнювати: ");
            pole = Console.ReadLine();
            Console.Write("\nВведiть нове значення: ");
            val = Console.ReadLine();
            sqlExpression = "UPDATE " + table + " SET " + pole + "='" + val + "' WHERE ID=" + help;
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            number = command.ExecuteNonQuery();
            try
            {
                number = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Exception error = new Exception("Помилка виконання!", ex);
                throw error;
            }
            Console.Write("Натиснiть Enter для виходу");
            Console.ReadLine();           
        }
        /// <summary>
        /// Запит 1
        /// </summary>
        static public void Select1()
        {
            string nameGal;
            OpenConnection(connectionString);
            Console.WriteLine("Введiть назву галактики (MilkyWay)");
            nameGal = Console.ReadLine();
            string sql = "SELECT GALAXY.NAME as GALAXY, PLANET.NAME as PLANET, SATELLITE.NAME as SATELLITE FROM GALAXY JOIN PLANET ON PLANET.ID_GALAXY=GALAXY.ID JOIN SATELLITE ON SATELLITE.ID_PLANET=PLANET.ID WHERE PLANET.LIFE='Yes' AND GALAXY.NAME = '" + nameGal+"'";
            ///Використання адаптера даних
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ///Представляє на стороні клієнта зовнішні дані
            DataTable dt = ds.Tables[0];
            foreach (DataColumn column in dt.Columns)
                Console.Write("{0,-15}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Запит 2
        /// </summary>
        static public void Select2()
        {
            OpenConnection(connectionString);
            string sql = "SELECT PLANET.NAME as PLANET, PLANET.RADIUS as PLANET_RADIUS, SATELLITE.NAME as SATELLITE, SATELLITE.RADIUS AS SATELLITE_RADIUS FROM PLANET JOIN SATELLITE ON SATELLITE.ID_PLANET=PLANET.ID WHERE PLANET.RADIUS=(SELECT MIN(RADIUS) FROM PLANET)";
            ///Використання адаптера даних
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ///Представляє на стороні клієнта зовнішні дані
            DataTable dt = ds.Tables[0];
            foreach (DataColumn column in dt.Columns)
                Console.Write("{0,-15}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Запит 3
        /// </summary>
        static public void Select3()
        {
            OpenConnection(connectionString);
            string sql = "SELECT GALAXY.NAME as GALAXY, PLANET.NAME as PLANET, COUNT(SATELLITE.NAME) as COUNT_SATELLITES FROM GALAXY JOIN PLANET ON PLANET.ID_GALAXY=GALAXY.ID JOIN SATELLITE ON SATELLITE.ID_PLANET=PLANET.ID GROUP BY GALAXY.NAME, PLANET.NAME";
            ///Використання адаптера даних
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ///Представляє на стороні клієнта зовнішні дані
            DataTable dt = ds.Tables[0];
            foreach (DataColumn column in dt.Columns)
                Console.Write("{0,-15}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Запит 4
        /// </summary>
        static public void Select4()
        {
            OpenConnection(connectionString);
            string sql = "SELECT DISTINCT GALAXY.NAME FROM GALAXY JOIN PLANET ON GALAXY.ID = PLANET.ID_GALAXY WHERE PLANET.TEMPERATURE>0";
            ///Використання адаптера даних
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ///Представляє на стороні клієнта зовнішні дані
            DataTable dt = ds.Tables[0];
            foreach (DataColumn column in dt.Columns)
                Console.Write("{0,-15}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Меню програми
        /// </summary>
        static public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Контрольна робота. Виконав: Процюк Юрiй Група:IC-63 Варiант:11");
            Console.WriteLine("Виберiть дiю:");
            Console.WriteLine("1. Видалити");
            Console.WriteLine("2. Оновити");
            Console.WriteLine("3. Запит 1");
            Console.WriteLine("4. Запит 2");
            Console.WriteLine("5. Запит 3");
            Console.WriteLine("6. Запит 4");
            Console.WriteLine("7. Вихiд");
            Console.Write("\n" + "Введiть команду: ");
            char ch = char.Parse(Console.ReadLine());

            switch (ch)
            {
                case '1':
                    Console.Clear();
                    Delete();
                    CloseConnection();
                    break;
                case '2':
                    Console.Clear();
                    Update();
                    CloseConnection();
                    break;
                case '3':
                    Console.Clear();
                    Select1();
                    CloseConnection();
                    break;
                case '4':
                    Console.Clear();
                    Select2();
                    CloseConnection();
                    break;
                case '5':
                    Console.Clear();
                    Select3();
                    CloseConnection();
                    break;
                case '6':
                    Console.Clear();
                    Select4();
                    CloseConnection();
                    break;
                case '7':
                    return;
            }
            Menu();

        }
        static void Main(string[] args)
        {
            Menu();
            Console.Read();
        }

    }
}
