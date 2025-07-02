using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class AuthManager : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputContrasena;

    public TMP_InputField inputGato_id;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void Registrar()
    {
        StartCoroutine(Enviar("registro_usuario.php",
            ("nombre", inputNombre.text),
            ("contrasena", inputContrasena.text),
            ("gato_id", inputGato_id.text)
        ));
    }

    public void Login()
    {
        StartCoroutine(Enviar("login_usuario.php",
            ("nombre", inputNombre.text),
            ("contrasena", inputContrasena.text)
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
