using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class VerDatosEstadisticas : MonoBehaviour
{
    public TMP_InputField inputUsuarioId, inputMinijuegoId;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void VerRanking()
    {
        StartCoroutine(Enviar("ranking_minijuego.php", ("minijuegos_id", inputMinijuegoId.text)));
    }

    public void VerTodosMisPuntajes()
    {
        StartCoroutine(Enviar("ver_puntajes_usuario.php", ("usuario_id", inputUsuarioId.text)));
    }

    public void VerUsuariosPorAvatar()
    {
        StartCoroutine(Enviar("ver_usuarios_por_avatar.php"));
    }

    IEnumerator Enviar(string archivo, params (string, string)[] datos)
    {
        WWWForm form = new WWWForm();
        foreach (var (k, v) in datos) form.AddField(k, v);
        UnityWebRequest www = UnityWebRequest.Post(baseURL + archivo, form);
        yield return www.SendWebRequest();
        mensaje.text = www.result == UnityWebRequest.Result.Success ? www.downloadHandler.text : "Error: " + www.error;
    }
}
