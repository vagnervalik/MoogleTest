namespace Classes;

class Vector{
    private TokenArr tokens;
    private int[] vector;
    public Vector(string[] words){
        this.tokens = new TokenArr(words);
    }
}