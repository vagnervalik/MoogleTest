using System;
using System.IO;
namespace Classes;

class Program{
    static void Main(){
        DataBase Docs = new DataBase("Content");
        TestDataBase(Docs);
    }
    static void TestDataBase(DataBase Docs){
        Console.WriteLine("Database loaded!");
        Console.WriteLine("Total Documents: " + Docs.Count());
        Console.WriteLine("Total Words: " + Docs.NumOfWords());
        for (int i = 0; i < Docs.Count(); i++){
            Console.WriteLine("No. of words in Doc" + i + ": " + Docs.NumOfWords(i));
        }
        Console.WriteLine("Vocabulary");
        for (int i = 0; i < 10; i++){
            Console.Write(i + ": " + Docs.Vocabulary()[i] + "   ");
        }
        Console.WriteLine("");
        Console.WriteLine("Documents");
        for (int i = 0; i < Docs.Count(); i++){
            Console.WriteLine("Doc " + i + ":");
            for (int j = 0; j < 10; j++){
                Console.Write(j + ": " + Docs.Get(i)[j] + "   ");
            }
            Console.WriteLine("");
        }
    }
}