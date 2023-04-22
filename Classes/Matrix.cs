namespace Classes;

class Matrix{
    private DataBase Docs;
    private float[] Idfs;
    private string[] voc;
    private Vector[] matrix;
    private Dictionary<string, Dictionary<int, (float tf_idf, float tf)>> Dict;

    public Matrix(DataBase Docs){
        this.Docs = Docs;
        this.voc = this.Docs.Vocabulary();
        this.Idfs = this.GetIdfs();
        this.matrix = this.GetMatrix();
        this.Dict = this.GetDictionary();
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

    public Dictionary<string, Dictionary<int, (float tf_idf, float tf) >> GetDictionary(){
        Dictionary<string, Dictionary<int, (float tf_idf, float tf)>> Dict = new Dictionary<string, Dictionary<int, (float tf_idf, float tf)>>();
        for(int i = 0; i < this.voc.Length; i++){
            Dict.Add(this.voc[i], new Dictionary<int, (float tf_idf, float tf)>());
            for(int j = 0; j < this.Docs.Count(); j++){
                Dict[this.voc[i]].Add(j, (this.matrix[j].GetTfidf()[i], this.matrix[j].GetTf()[i]));
            }
        }
        return Dict;
    }        
    
    public float[] score(string query){
        float[] scores = new float[this.Docs.Count()];
        for(int i = 0; i < this.Docs.Count(); i++){
            scores[i] = this.Dict[query][i].tf_idf;
        }
        return scores;
    }
}