namespace Classes;

class Token{
    private Dictionary<char, int> chars;
    private string word;
    private int[] token;
    private int value;
    public Token(string word){
        this.chars = this.MakeDictionary();
        this.word = word;
        this.token = this.Tokenize();
        this.value = this.CalcValue();
    }
    private Dictionary<char, int> MakeDictionary(){
        Dictionary<char, int> chars = new Dictionary<char, int>();
        int value = 1;
        char[] vowels = new char[]{ 'a', 'á', 'à', 'â', 'ä', 'ã', 'å', 'A', 'Á', 'À', 'Â', 'Ä', 'Ã', 'Å', 'e', 'é', 'è', 'ê', 'ë', 'E', 'É', 'È', 'Ê', 'Ë', 'i', 'í', 'ì', 'î', 'ï', 'I', 'Í', 'Ì', 'Î', 'Ï', 'o', 'ó', 'ò', 'ô', 'ö', 'õ', 'ø','O','Ó','Ò','Ô','Ö','Õ','Ø', 'u','ú','ù','û','ü','U','Ú','Ù','Û','Ü'};
        char[] consonants = new char[]{'b', 'B', 'c', 'C', 'ç', 'Ç', 'd', 'D', 'f','F','g','G','h','H', 'j','J','k','K', 'l', 'L', 'm', 'M', 'n', 'N', 'ñ', 'Ñ', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'v', 'V', 'x', 'X', 'y', 'Y', 'z', 'Z'};
        int i = 0;
        foreach (char c in vowels){
            chars.Add(vowels[i], value);
            value++;
            i++;
        }
        i = 0;
        foreach (char c in consonants){
            chars.Add(consonants[i], value);
            value++;
            i++;
        }
        return chars;
    }

    private int[] Tokenize(){
        int[] ints = new int[this.word.Length];
        int i = 0;
        foreach(char c in this.word){
            if (!chars.ContainsKey(c)){
                ints[i] = 0;
            } else ints[i] = this.chars[c];
            i++;
        }
        return ints;
    }

    private int CalcValue(){
        int count = 0;
        int i = 0;
        foreach(int val in this.token){
            count += this.token[i];
            i++;
        }
        count *= this.token.Length;
        return count;
    }

    public void GetValue(){
        Console.WriteLine(this.value);
    }

    public void GetToken(){
        Console.Write("[");
        foreach(int i in this.token){
            Console.Write(i + ", ");
        }
        Console.Write("]\n");
    }
}