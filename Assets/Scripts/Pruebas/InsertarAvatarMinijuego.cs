using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class InsertarAvatarMinijuego : MonoBehaviour
{
    public TMP_InputField inputNombreAvatar, inputNombreMinijuego;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void InsertarAvatar()
    {
        StartCoroutine(Enviar("insert_avatar.php", ("nombre", inputNombreAvatar.text)));
    }

    public void InsertarMinijuego()
    {
        StartCoroutine(Enviar("insert_minijuego.php", ("nombre", inputNombreMinijuego.text)));
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
