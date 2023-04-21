using System.Text.RegularExpressions;
namespace Classes;

class DataBase{
    private string address;    //URL FOR THE DATABASE.
    private string[] AllText;  //ALL THE TEXT FROM EACH DOCUMENT.
    private string[][] Docs;   //ALL THE TEXT FROM EACH DOCUMENT SEPARATED INTO WORDS.
    private string[] AllWords; //ALL THE WORDS FROM ALL DOCUMENTS IN TOTAL.

    //CONSTRUCTOR
    public DataBase(string address){
        this.address = address;
        this.AllText = this.LoadDataBase();
        this.Docs = this.GetWords();
        this.AllWords = this.GetAllWords();
    } 

    //CONSTRUCTOR AID FOR THE FIELD AllText. RETURNS AN ARRAY WITH THE TEXT OF ALL DOCUMENTS IN THE FORM OF STRINGS.
    private string[] LoadDataBase(){
        string[] Files = Directory.GetFiles(address);
        string[] AllFiles = new String[Files.Length];
        for (int i = 0; i < Files.Length; i++){
            AllFiles[i] = File.ReadAllText(Files[i]);
        }
        return AllFiles;
    }

    //CONSTRUCTOR AID FOR THE FIELD Docs. RETURNS ALL THE WORDS FROM EACH DOCUMENT IN THE FORM OF A STRING ARRAY.
    private string[][] GetWords(){
        List<string[]> AllWords = new List<string[]>();
        for (int i = 0; i < this.Count(); i++){
            AllWords.Add(Regex.Split(this.AllText[i].ToLower(), "[^a-zA-Z]+").Where(x => !string.IsNullOrEmpty(x)).ToArray());
        }
        string[][] Words = AllWords.ToArray();
        return Words;
    }

    //CONSTRUCTOR AID FOR THE FIELD AllWords. RETURNS ALL THE WORDS FROM ALL THE DOCUMENTS WITHOUT DUPLICATES.
    private string[] GetAllWords(){
        List<string> wrds= new List<string>();
        for(int i = 0; i < this.Count(); i++){
            for(int j = 0; j < this.Get(i).Length; j++){
                if(!(wrds.Contains(this.Get(i)[j]))){
                    wrds.Add(this.Get(i)[j]);
                }
            }
        }
        string[] words = wrds.ToArray();
        Array.Sort(words);
        return words;
    }
    
    //RETURNS THE TOTAL COUNT OF THE WORDS FROM ALL DOCUMENTS.
    public int NumOfWords(){
        return this.AllWords.Length;
    }

    //RETURNS THE TOTAL COUNT OF THE WORDS FROM A INDEX-SPECIFIED DOCUMENT.
    public int NumOfWords(int pos){
        return this.Docs[pos].Length;
    }

    //RETURNS AN ARRAY WITH ALL THE WORDS FROM ALL DOCUMENTS WITHOUT DUPLICATES.
    public string[] Vocabulary(){
       return this.AllWords;
    }

    //RETURNS ALL THE WORDS IN A DOCUMENTS BASED ON A GIVEN INDEX.
    public string[] Get(int pos){
        return this.Docs[pos];
    }

    //RETURNS THE NUMBER OF DOCUMENTS AT THE DATABASE FOLDER.
    public int Count(){
        return this.AllText.Length;
    }
}