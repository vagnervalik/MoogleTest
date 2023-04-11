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
        char[] chars = new char[]{' ', ',', '.', '`', '!', '~', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', ':', ';', '"', '\'', '\\', '|', '<', '>', '?', '/', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\r' , '\n'};
        List<string[]> AllWords = new List<string[]>();
        for (int i = 0; i < this.Count(); i++){
            AllWords.Add(this.AllText[i].Trim(chars).ToLower().Split(chars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));
        }
        string[][] Words = AllWords.ToArray();
        return Words;
    }
    //CONSTRUCTOR AID FOR THE FIELD AllWords. RETURNS ALL THE WORDS FROM ALL THE DOCUMENTS WITHOUT DUPLICATES.
    private string[] GetAllWords(){
        List<string> wrds= new List<string>();
        bool isNew = true;
        for (int i = 0; i < this.Count(); i++){
            for(int j = 0; j < this.Get(i).Length; j++){
                isNew = true;
                for(int k = j-1; k >= 0; k--){
                    if(this.Get(i)[j] == this.Get(i)[k]){
                        isNew = false;
                        break;
                    }
                }
                if (isNew){
                    wrds.Add(this.Get(i)[j]);
                }
            }
        }
        return wrds.ToArray();
    }
    //RETURNS THE TOTAL COUNT OF THE WORDS FROM ALL DOCUMENTS.
    public int NumOfWords(){
        return this.AllWords.Length;
    }
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