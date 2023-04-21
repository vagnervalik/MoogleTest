namespace Classes;

class Vector{
    private string[] words;
    private float[] vector;

    public Vector(string[] words, Vector Idfs){
        this.words = words;
        this.vector = this.Vectorize();
    }

    public float[] Vectorize(){
        throw new NotImplementedException();
    } 
}