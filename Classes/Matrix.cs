namespace Classes;

class Matrix{
    private DataBase Docs;
    private float[] Idfs;
    // private Vector[] matrix;

    public Matrix(DataBase Docs){
        this.Docs = Docs;
        this.Idfs = this.GetIdfs();
        // this.matrix = this.GetMatrix();
    }

    public float[] GetIdfs(){
        int size = this.Docs.Count();
        float[] idfs = new float[this.Docs.NumOfWords()];
        int count = 0;
        for(int i = 0; i < this.Docs.NumOfWords(); i++){
            for(int j = 0; j < size; j++){
                if(Array.Exists(this.Docs.Get(j), element => element == this.Docs.Vocabulary()[i])){
                    count ++;
                }
            }
            idfs[i] = Convert.ToSingle(Math.Round(Convert.ToDouble(size/count), 4));
        }
        return idfs;
    }

    public void Display(){
        Console.Write("[");
        foreach(float n in this.Idfs){
            Console.Write(n + ", ");
        }
        Console.Write("]");
    }

    // public Vector[] GetMatrix(){
    //     throw new NotImplementedException();
    // }
}