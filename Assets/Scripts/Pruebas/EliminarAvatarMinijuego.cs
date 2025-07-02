using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class EliminarAvatarMinijuego : MonoBehaviour
{
    public TMP_InputField inputGatoId, inputMinijuegoId;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void EliminarAvatar()
    {
        StartCoroutine(Enviar("eliminar_avatar.php", ("gato_id", inputGatoId.text)));
    }

    public void EliminarMinijuego()
    {
        StartCoroutine(Enviar("eliminar_minijuego.php", ("minijuegos_id", inputMinijuegoId.text)));
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