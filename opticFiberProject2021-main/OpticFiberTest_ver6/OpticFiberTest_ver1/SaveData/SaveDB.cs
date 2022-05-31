using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using OpticFiberTest_ver1.Classes_SFF8636;

namespace OpticFiberTest_ver1.SaveData
{
    class SaveDB
    {

        static public string connect(Dictionary<int, SFF8636> MainDictionary)
        {

// This is the query which will create a new table in our database file with three columns. An auto increment column called "ID", and two NVARCHAR type columns with the names "Key" and "Value"
string createTableQuery = @"CREATE TABLE IF NOT EXISTS [test_results] (
                          [Number] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [ID] NVARCHAR(2048) NOT NULL,
                          [Byte] NVARCHAR(2048) NOT NULL,
                          [Name] VARCHAR(2048)  NOT NULL,
                          [Date] VARCHAR(2048)  NOT NULL,
                          [PageNum] VARCHAR(2048)  NOT NULL,
                          [Status] VARCHAR(2048)  NOT NULL
                          )";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\opticFiberTestResult.db3";

            System.Data.SQLite.SQLiteConnection.CreateFile(filePath);        // Create the file which will be hosting our database
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + filePath))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                {
                    con.Open();                             // Open the connection to the database

                    com.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                    com.ExecuteNonQuery();                  // Execute the query

                    for (int i = 0; i < MainDictionary.Keys.Count(); i++)
                    {
                        string ID = MainDictionary[i + 1].GetAddress().ToString();
                        string Byte = MainDictionary[i + 1].GetTitle();
                        string Name = MainDictionary[i + 1].GethasRead();
                        string Date = "sff_8636";
                        string PageNum = MainDictionary[i + 1].GetPage().ToString();
                        string Status;
                        if (MainDictionary[i + 1].getColor() == "Green")
                        {
                            Status = "Passed";
                        }
                        else
                        {
                            Status = "Test Failed";
                        }

                        com.CommandText = "INSERT INTO test_results (ID, Byte, Name, Date, PageNum, Status) Values ('" + ID + "','" + Byte + "','" + Name + "','" + Date + "','" + PageNum + "','" + Status + "')";     // Add the first entry into our database 
                        com.ExecuteNonQuery();      // Execute the query
                    }

                    con.Close();        // Close the connection to the database
                }
            }

            return "The data was added successfully";
        }
    }
}
