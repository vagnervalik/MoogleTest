using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Classes;

class Program{
    static void Main(){
        Console.WriteLine("Cargando...");
        int stTime = Environment.TickCount;
        DataBase Docs = new DataBase("Content");
        Matrix M = new Matrix(Docs);
        Console.WriteLine("Vocabulary");
        for (int i = 0; i < 10; i++){
            Console.Write(Docs.Vocabulary()[i] + "   ");
        }
        Console.WriteLine("\n Idfs");
        M.Display();
        Console.WriteLine("Tf-idfs");
        foreach(Vector v in M.Get()){
            v.Display();
        }
        TestDataBase(Docs);
        foreach(float f in M.score("bear")){
            Console.Write("\n" + f + ",    ");
        }
        Console.WriteLine("\n Time elapsed: {0} seconds", (Environment.TickCount - stTime)/1000);
        static void TestDataBase(DataBase Docs){
        Console.WriteLine("Database loaded!");
        Console.WriteLine("Total Documents: " + Docs.Count());
        Console.WriteLine("Total Words: " + Docs.NumOfWords());
        for (int i = 0; i < Docs.Count(); i++){
            Console.WriteLine("No. of words in Doc" + i + ": " + Docs.NumOfWords(i));
        }
        Console.WriteLine("Vocabulary");
        for (int i = 0; i < 50; i++){
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
}