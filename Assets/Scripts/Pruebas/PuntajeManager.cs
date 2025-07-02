using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class PuntajeManager : MonoBehaviour
{
    public TMP_InputField inputUsuarioId, inputJuegoId, inputPuntaje;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void InsertarPuntaje()
    {
        StartCoroutine(Enviar("actualizar_puntaje.php",
            ("usuario_id", inputUsuarioId.text),
            ("minijuegos_id", inputJuegoId.text),
            ("puntos", inputPuntaje.text)
        ));
    }

    public void VerMiPuntaje()
    {
        StartCoroutine(Enviar("ver_puntaje_usuario.php",
            ("usuario_id", inputUsuarioId.text),
            ("minijuegos_id", inputJuegoId.text)
        ));
    }

    IEnumerator Enviar(string archivo, params (string, string)[] campos)
    {
        WWWForm form = new WWWForm();
        foreach (var (k, v) in campos) form.AddField(k, v);
        UnityWebRequest www = UnityWebRequest.Post(baseURL + archivo, form);
        yield return www.SendWebRequest();
        mensaje.text = www.result == UnityWebRequest.Result.Success ? www.downloadHandler.text : "Error: " + www.error;
    }
}
