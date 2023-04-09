namespace Classes;

class DataBase{
    private string address;
    private string[] AllText;
    private string[][] Docs;
    private string[] AllWords;

    public DataBase(string address){
        this.address = address;
        this.AllText = this.LoadDataBase();
        this.Docs = this.GetWords();
        this.AllWords = this.GetAllWords();
    } 

    public string[] LoadDataBase(){
        string[] Files = Directory.GetFiles(address);
        string[] AllFiles = new String[Files.Length];
        for (int i = 0; i < Files.Length; i++){
            AllFiles[i] = File.ReadAllText(Files[i]);
        }
        return AllFiles;
    }

    public string[][] GetWords(){
        char[] chars = new char[]{' ', ',', '.', '`', '!', '~', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', ':', ';', '"', '\'', '\\', '|', '<', '>', '?', '/', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\r' , '\n'};
        List<string[]> AllWords = new List<string[]>();
        for (int i = 0; i < this.Count(); i++){
            AllWords.Add(this.AllText[i].Trim(chars).ToLower().Split(chars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));
        }
        string[][] Words = AllWords.ToArray();
        return Words;
    }

    public string[] GetAllWords(){
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

    public void DisplayAllWords(){
        int i = 1;
        foreach(string word in this.AllWords){
            Console.Write(i + ": " + word + "   ");
            if (i > 100){
                break;
            }
            i++;

        }
    }

    public void Display(int pos){
        if (pos > this.Get(pos).Length || pos < 0){
            throw new ArgumentException("Index must be inside the bounds of the array");
        }
        int i = 1;
        foreach(string word in this.Get(pos)){
            Console.Write(i + " = " + $"'{word}'" + "   ");
            i++;
        }
    }

    public string[] Get(int pos){
        return this.Docs[pos];
    }

    public int Count(){
        return this.AllText.Length;
    }
}