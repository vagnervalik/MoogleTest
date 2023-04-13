namespace Classes;

class Token{
    private Dictionary<char, int> chars;
    private string token;
    public Token(string word){
        this.chars = this.MakeDictionary();
        this.token = word;
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
}