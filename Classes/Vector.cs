using System.Linq;
namespace Classes;

class Vector{
    private string[] words;
    private string[] voc;
    private float[] idfs;
    private float[] vector;

    public Vector(string[] words, string[] vocabulary, float[] Idfs){
        this.words = words;
        this.voc = vocabulary;
        this.idfs = Idfs;
        this.vector = this.Vectorize();
    }

    public float[] Vectorize(){
        float[] tfidf = new float[this.idfs.Length];
        float count = 0f;
        for(int i = 0; i < this.idfs.Length; i++){
            count = this.words.Count(x => x == this.voc[i]);
            tfidf[i] = (count/Convert.ToSingle(this.words.Length)) * this.idfs[i];
        }
        return tfidf;
    } 

    public float[] Get(){
        return this.vector;
    }

    public void Display(){
        for(int i = 0; i < 10; i++){
            Console.Write(this.vector[i] + ",    ");
        }
        Console.WriteLine();
    }
}