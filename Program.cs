using System;
using System.IO;
namespace Classes;

class Program{
    static void Main(){
        DataBase Docs = new DataBase("Content");
        Console.WriteLine("Database loaded!");
        Console.WriteLine(Docs.Count());
        Docs.GetAllSizes();
    }
}