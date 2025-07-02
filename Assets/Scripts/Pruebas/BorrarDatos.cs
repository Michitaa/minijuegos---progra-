using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class BorrarDatos : MonoBehaviour
{
    public TMP_InputField inputUsuarioId, inputJuegoId;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void BorrarPuntaje()
    {
        StartCoroutine(Enviar("eliminar_puntaje.php",
            ("usuario_id", inputUsuarioId.text),
            ("minijuegos_id", inputJuegoId.text)
        ));
    }

    public void BorrarTodosPuntajesDelMinijuego()
    {
        StartCoroutine(Enviar("eliminar_puntajes_minijuego.php",
            ("minijuegos_id", inputJuegoId.text)
        ));
    }

    public void BorrarUsuario()
    {
        StartCoroutine(Enviar("borrar_usuario.php",
            ("usuario_id", inputUsuarioId.text)
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
