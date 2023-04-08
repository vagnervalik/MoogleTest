namespace Classes;

class DataBase{
    private string address;
    private string[] Docs;
    public DataBase(string address){
        this.address = address;
        this.Docs = this.LoadDataBase();
    } 
    public string[] LoadDataBase(){
        string[] Files = Directory.GetFiles(address);
        string[] AllFiles = new String[Files.Length];
        for (int i = 0; i < Files.Length; i++){
            AllFiles[i] = File.ReadAllText(Files[i]);
        }
        return AllFiles;
    }
    public string Get(int pos){
        return this.Docs[pos];
    }
    public int Count(){
        return this.Docs.Length;
    }
}