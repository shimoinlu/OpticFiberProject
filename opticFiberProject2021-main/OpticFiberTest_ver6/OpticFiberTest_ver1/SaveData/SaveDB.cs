using System;
using System.Collections.Generic;
using System.Linq;
using OpticFiberTest_ver1.Classes_SFF8636;

namespace OpticFiberTest_ver1.SaveData
{
    class SaveDB
    {

        static public string createDB(Dictionary<int, SFF8636> MainDictionary)
        {

            // This is the query which will create a new table in our database file with three columns. An auto increment column called "ID", and two NVARCHAR type columns with the names "Key" and "Value"
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [test_results] (
                [Number] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                [Byte] NVARCHAR(2048) NOT NULL,
                [Name] VARCHAR(2048)  NOT NULL,
                [Data] VARCHAR(2048)  NOT NULL,
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
                        string Byte = MainDictionary[i + 1].GetAddress().ToString();
                        string Name = MainDictionary[i + 1].GetTitle();
                        string Data = MainDictionary[i + 1].GethasRead();
                        string PageNum = MainDictionary[i + 1].GetPage().ToString();
                        string Status;
                        if (MainDictionary[i + 1].getColor() == "Green")
                        {
                            Status = "Test Passed";
                        }
                        else
                        {
                            Status = "Test Failed";
                        }

                        com.CommandText = "INSERT INTO test_results (Byte, Name, Data, PageNum, Status) Values ('" + Byte + "','" + Name + "','" + Data + "','" + PageNum + "','" + Status + "')";     // Add the first entry into our database 
                        com.ExecuteNonQuery();      // Execute the query
                    }

                    con.Close();        // Close the connection to the database
                }
            }

            return "data has been saved succesfully";
        }
    }
}
