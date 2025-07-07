using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class ActualizarNombreUI : MonoBehaviour
{
    public TMP_InputField inputNombreActual;
    public TMP_InputField inputContrasena;
    public TMP_InputField inputNuevoNombre;
    public TMP_Text mensajeTexto;

    public void EnviarCambio()
    {
        StartCoroutine(CambiarNombre());
    }

    IEnumerator CambiarNombre()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_actual", inputNombreActual.text);
        form.AddField("contrasena", inputContrasena.text);
        form.AddField("nuevo_nombre", inputNuevoNombre.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego/actualizar_nombre_usuario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                mensajeTexto.text = www.downloadHandler.text;
                Debug.Log("Respuesta: " + www.downloadHandler.text);
            }
            else
            {
                mensajeTexto.text = "Error de conexión: " + www.error;
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
