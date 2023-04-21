namespace Classes;

class Matrix{
    private DataBase Docs;
    private float[] Idfs;
    private string[] voc;
    private Vector[] matrix;

    public Matrix(DataBase Docs){
        this.Docs = Docs;
        this.voc = this.Docs.Vocabulary();
        this.Idfs = this.GetIdfs();
        this.matrix = this.GetMatrix();
    }

    public float[] GetIdfs(){
        float size = Convert.ToSingle(this.Docs.Count());
        float[] idfs = new float[this.Docs.NumOfWords()];
        float count = 0f;
        for(int i = 0; i < this.Docs.NumOfWords(); i++){
            count = 0;
            for(int j = 0; j < size; j++){
                if(Array.Exists(this.Docs.Get(j), element => element == this.Docs.Vocabulary()[i])){
                    count ++;
                }
            }
            idfs[i] = Convert.ToSingle(Math.Log(size/count));
        }
        return idfs;
    }

    public void Display(){
        int i = 0;
        Console.Write("[");
        foreach(float n in this.Idfs){
            Console.Write(n + ",    ");
            i++;
            if (i == 10){
                break;
            }
        }
        Console.Write("]\n");
    }

    private Vector[] GetMatrix(){
        Vector[] All = new Vector[this.Docs.Count()];
        for(int i = 0; i < this.Docs.Count(); i++){
            All[i] = new Vector(this.Docs.Get(i), this.voc, this.Idfs);
        }
        return All;
    }

    public Vector[] Get(){
        return this.matrix;
    }
}