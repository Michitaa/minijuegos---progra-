using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class EliminarUsuarioUI : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputContrasena;
    public TMP_Text mensajeTexto;

    public void EnviarEliminacion()
    {
        StartCoroutine(EliminarUsuario());
    }

    IEnumerator EliminarUsuario()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", inputNombre.text);
        form.AddField("contrasena", inputContrasena.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego/eliminar_usuario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                mensajeTexto.text = www.downloadHandler.text;
                Debug.Log("Respuesta: " + www.downloadHandler.text);

                
                PlayerPrefs.DeleteKey("usuario_id");
                PlayerPrefs.DeleteKey("ultimo_puntaje");
            }
            else
            {
                mensajeTexto.text = "Error de conexión: " + www.error;
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
