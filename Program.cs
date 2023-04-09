using System;
using System.IO;
namespace Classes;

class Program{
    static void Main(){
        DataBase Docs = new DataBase("Content");
        Console.WriteLine("Database loaded!");
        Console.WriteLine(Docs.TotalWords());
        for(int i = 0; i < Docs.Count(); i++){
            Console.WriteLine(i + ": " + Docs.TotalWords(i));
        }
    }
}