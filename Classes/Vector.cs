using System.Linq;
namespace Classes;

class Vector{
    private string[] words;
    private string[] voc;
    private float[] idfs;
    private float[] tfs;
    private float[] vector;

    public Vector(string[] words, string[] vocabulary, float[] Idfs){
        this.words = words;
        this.voc = vocabulary;
        this.idfs = Idfs;
        var result = this.Vectorize();
        this.vector = result.Item1;
        this.tfs = result.Item2;
    }

    public (float[],float[]) Vectorize(){
        float[] tfidf = new float[this.idfs.Length];
        float[] tf = new float[this.idfs.Length];
        float count = 0f;
        for(int i = 0; i < this.idfs.Length; i++){
            count = this.words.Count(x => x == this.voc[i]);
            tfidf[i] = (count/Convert.ToSingle(this.words.Length)) * this.idfs[i];
            tf[i] = (count/Convert.ToSingle(this.words.Length));
        }
        return (tfidf, tf);
    } 

    public float[] GetTfidf(){
        return this.vector;
    }
    public float[] GetTf(){
        return this.tfs;
    }
    public void Display(){
        for(int i = 0; i < 10; i++){
            Console.Write(this.vector[i] + ",    ");
        }
        Console.WriteLine();
    }
    public int Size(){
        return this.vector.Length;
    }
    public float Multiply(Vector V){
        if (this.Size() != V.Size()){
            throw new ArgumentException("Vector must be {0} elements long", this.Size());
        }
        float count = 0f;
        for(int i = 0; i < this.Size(); i++){
            count += this.vector[i] * V[i];
        }
        return count;
    }
}