﻿namespace csvParsNPush;

public class Program
{
    public static void Main(string[] args)
    {
        string csvPath = "your csv file path";
        string connectionString = "Server=yourServer;Database=yourDB;User Id=your user id ;Password=your password;";
        string tableName = "your table name ";
        int countOfFields = 5; //insert count of fields in your csv file
        
        Parser parser = new Parser();
        Pusher pusher = new Pusher(connectionString, tableName);

        List<Dictionary<string, string?>> data = parser.ParseCsv(csvPath, countOfFields);

        Console.WriteLine("Parsed data:");
        foreach (var record in data)
        {
            Console.WriteLine("{" + string.Join(", ", record) + "}");
        }

        pusher.PushToDB(data);
    }
}