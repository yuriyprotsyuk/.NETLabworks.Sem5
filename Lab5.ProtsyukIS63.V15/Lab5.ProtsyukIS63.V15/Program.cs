using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Lab5.ProtsyukIS63.V15
{
    class Program
    {
        /// <summary>
        /// рядок підключення до БД
        /// </summary>
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        /// <summary>
        /// Точка входу в програму
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Menu();
            Console.Read();
        }
        /// <summary>
        /// Меню дій над таблицею
        /// </summary>
        static public void FragmentMenu()
        {
            Console.WriteLine();
            Console.Write("1-Додати    ");
            Console.Write("2-Редагувати     ");
            Console.Write("3-Видалити   ");
            Console.WriteLine("4-Назад    ");
            Console.Write("\n" + "Введiть команду: ");
        }

        /// <summary>
        /// Головне меню
        /// </summary>
        static public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Лабораторна работа №5 Виконав: Процюк Юрiй Група:IC-63 Варiант:15");
            Console.WriteLine("Виберiть таблицю:");
            Console.WriteLine("1. Диплом (DIPLOMA)");
            Console.WriteLine("2. Спiвробiтники (EMPLOYEE)");
            Console.WriteLine("3. Вiддiли (DIVISION)");
            Console.WriteLine("4. Прилади (DEVICES)");
            Console.WriteLine("5. Вихiд");
            Console.Write("\n" + "Введiть команду: ");
            char ch = char.Parse(Console.ReadLine());

            switch (ch)
            {
                case '1':
                    Console.Clear();
                    ///Нове підключення до БД
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM DIPLOMA";
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
                                Console.Write("{0,-18}", cell);
                            Console.WriteLine();
                        }
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                                ///Додання запису
                            case '1':
                                Console.WriteLine("Введiть значення для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("QUALIFICATION="); newRow["QUALIFICATION"] = Console.ReadLine();
                                Console.Write("EDUCATION="); newRow["EDUCATION"] = Console.ReadLine();
                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                ///Оновити адаптер даних
                                adapter.Update(ds);
                                ds.Clear();
                                ///Заповнити адаптер даних
                                adapter.Fill(ds);
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                                ///Редагування запису таблиці
                            case '2':
                                Console.Write("Введiть ID, по якому будемо змiнювати значення: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведiть поле, яке будемо змiнювати: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть нове значення: ");
                                val = Console.ReadLine();
                                sqlExpression = "UPDATE DIPLOMA SET " + pole + "='" + val + "' WHERE ID=" + help;
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                                ///Видалення запису таблиці
                            case '3':
                                Console.Write("\nВведiть поле, по якому будемо видаляти рядок: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть значення, по якому будемо видаляти рядок: ");
                                val = Console.ReadLine();
                                if (pole == "ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM DIPLOMA WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM DIPLOMA WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;
                case '2':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM EMPLOYEE";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataColumn column in dt.Columns)
                            Console.Write("{0,-18}", column.ColumnName);
                        Console.WriteLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            var cells = row.ItemArray;
                            foreach (object cell in cells)
                                Console.Write("{0,-18}", cell);
                            Console.WriteLine();
                        }
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                Console.WriteLine("Введiть значення для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("CARD_NUMBER="); newRow["CARD_NUMBER"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("NAME="); newRow["NAME"] = Console.ReadLine();
                                Console.Write("ADRESS="); newRow["ADRESS"] = Console.ReadLine();
                                Console.Write("SPECIALITY="); newRow["SPECIALITY"] = Console.ReadLine();
                                Console.Write("DIPLOMA_ID="); newRow["DIPLOMA_ID"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("DIVISION_ID="); newRow["DIVISION_ID"] = Convert.ToInt32(Console.ReadLine());

                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                ds.Clear();
                                adapter.Fill(ds);
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '2':
                                Console.Write("Введiть ID, по якому будемо змiнювати значення: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведiть поле, яке будемо змiнювати: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть нове значення: ");
                                val = Console.ReadLine();
                                if (pole == "DIPLOMA_ID" || pole == "DIVISION_ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE EMPLOYEE SET " + pole + "=" + val1 + " WHERE ID=" + help;
                                }
                                else sqlExpression = "UPDATE EMPLOYEE SET " + pole + "='" + val + "' WHERE ID=" + help;
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '3':
                                Console.Write("\nВведiть поле, по якому будемо видаляти рядок: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть значення, по якому будемо видаляти рядок: ");
                                val = Console.ReadLine();
                                if (pole == "DIPLOMA_ID" || pole == "DIVISION_ID" || pole == "ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM EMPLOYEE WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM EMPLOYEE WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;
                case '3':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM DIVISION";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

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
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                Console.WriteLine("Введiть значення для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("NUMBER_DIVIS="); newRow["NUMBER_DIVIS"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("NAME="); newRow["NAME"] = Console.ReadLine();
                                Console.Write("MANEGER_ID="); newRow["MANEGER_ID"] = Convert.ToInt32(Console.ReadLine());
                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                ds.Clear();
                                adapter.Fill(ds);
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '2':
                                Console.Write("Введiть ID, по якому будемо змiнювати значення: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведiть поле, яке будемо змiнювати: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть нове значення: ");
                                val = Console.ReadLine();
                                if (pole == "NUMBER_DIVIS" || pole == "MANEGER_ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE DIVISION SET " + pole + "=" + val1 + " WHERE ID=" + help;
                                }
                                else sqlExpression = "UPDATE DIVISION SET " + pole + "='" + val + "' WHERE ID=" + help;                                
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '3':
                                Console.Write("\nВведiть поле, по якому будемо видаляти рядок: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть значення, по якому будемо видаляти рядок: ");
                                val = Console.ReadLine();
                                if (pole == "ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM DIVISION WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM DIVISION WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;
                case '4':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM DEVICES";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataColumn column in dt.Columns)
                            Console.Write("{0,-12}", column.ColumnName);
                        Console.WriteLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            var cells = row.ItemArray;
                            foreach (object cell in cells)
                                Console.Write("{0,-12}", cell);
                            Console.WriteLine();
                        }
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                Console.WriteLine("Введiть значення для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("INV_NUMBER="); newRow["INV_NUMBER"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("CHECK_DATE="); newRow["CHECK_DATE"] = Console.ReadLine();
                                Console.Write("EMPLOYEE_ID="); newRow["EMPLOYEE_ID"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("DIVISION_ID="); newRow["DIVISION_ID"] = Convert.ToInt32(Console.ReadLine());
                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                ds.Clear();
                                adapter.Fill(ds);
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '2':
                                Console.Write("Введiть ID, по якому будемо змiнювати значення: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведiть поле, яке будемо змiнювати: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть нове значення: ");
                                val = Console.ReadLine();
                                if (pole == "INV_NUMBER" || pole == "EMPLOYEE_ID" || pole == "DIVISION_ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE DEVICES SET " + pole + "=" + val1 + " WHERE ID=" + help;
                                }
                                else sqlExpression = "UPDATE DEVICES SET " + pole + "='" + val + "' WHERE ID=" + help; 
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '3':
                                Console.Write("\nВведiть поле, по якому будемо видаляти рядок: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведiть значення, по якому будемо видаляти рядок: ");
                                val = Console.ReadLine();
                                if (pole == "ID" || pole == "INV_NUMBER" || pole == "EMPLOYEE_ID" || pole == "DIVISION_ID")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM DEVICES WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM DEVICES WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Натиснiть Enter для виходу");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;                   
                case '5':
                    return;
            }
            Menu();
        }
  
    }
}
