using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class UsuarioConfig : MonoBehaviour
{
    public TMP_InputField inputUsuarioId, inputNuevoNombre, inputAvatarId, inputNuevaContrasena, inputContrasenaActual;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void CambiarNombre()
    {
        StartCoroutine(Enviar("actualizar_nombre_usuario.php",
            ("usuario_id", inputUsuarioId.text),
            ("contrasena", inputContrasenaActual.text),
            ("nuevo_nombre", inputNuevoNombre.text)
        ));
    }

    public void CambiarContrasena()
    {
        StartCoroutine(Enviar("cambiar_contrasena.php",
            ("usuario_id", inputUsuarioId.text),
            ("contrasena_actual", inputContrasenaActual.text),
            ("nueva_contrasena", inputNuevaContrasena.text)
        ));
    }

    public void CambiarAvatar()
    {
        StartCoroutine(Enviar("actualizar_avatar.php",
            ("usuario_id", inputUsuarioId.text),
            ("gato_id", inputAvatarId.text)
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


