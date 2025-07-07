[System.Serializable]
public class RankingItem
{
    public string nombre;
    public int puntos;
}

[System.Serializable]
public class RankingModel
{
    public string mensaje;
    public RankingItem[] data;
}