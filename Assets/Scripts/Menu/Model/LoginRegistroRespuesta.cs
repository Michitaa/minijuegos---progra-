[System.Serializable]
public class LoginRegistroRespuesta
{
    public bool success;
    public string mensaje;
    public int usuario_id;
    public int gato_id; // puede ignorarse si es para registro
}