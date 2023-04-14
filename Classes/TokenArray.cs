namespace Classes;

class TokenArr{
    private Token[] tokens;
    public TokenArr(string[] words){
        this.tokens = this.Tokenize(words);
    }
    private Token[] Tokenize(string[] words){
        Token[] news = new Token[words.Length];
        for(int i = 0; i < words.Length; i++){
            news[i] = new Token(words[i]);
        }
        return news;
    }
    public Token Get(int pos){
        return this.tokens[pos];
    }
    public void Display(){
        foreach(Token x in this.tokens){
            Console.WriteLine(x.Get());
        }
    }
    public int Size(){
        return this.tokens.Length;
    }
}