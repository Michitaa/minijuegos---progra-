using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputContrasena;
    public TMP_Text mensaje;
    string baseURL = "http://localhost/juego/";

    public void Registrar()
    {
        StartCoroutine(EnviarRegistro());
    }

    public void Login()
    {
        StartCoroutine(EnviarLogin());
    }

    IEnumerator EnviarRegistro()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", inputNombre.text);
        form.AddField("contrasena", inputContrasena.text);

        UnityWebRequest www = UnityWebRequest.Post(baseURL + "registro_usuario.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var data = JsonUtility.FromJson<LoginRegistroRespuesta>(www.downloadHandler.text);
            mensaje.text = data.mensaje;

            if (data.success)
            {
                PlayerPrefs.SetInt("usuario_id", data.usuario_id);
                PlayerPrefs.SetString("usuario_nombre", inputNombre.text);
                SceneManager.LoadScene("SeleccionAvatar");
            }
        }
        else
        {
            mensaje.text = "Error de red: " + www.error;
        }
    }

    IEnumerator EnviarLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", inputNombre.text);
        form.AddField("contrasena", inputContrasena.text);

        UnityWebRequest www = UnityWebRequest.Post(baseURL + "login_usuario.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var data = JsonUtility.FromJson<LoginRegistroRespuesta>(www.downloadHandler.text);
            mensaje.text = data.mensaje;

            if (data.success)
            {
                PlayerPrefs.SetInt("usuario_id", data.usuario_id);
                PlayerPrefs.SetInt("gato_id", data.gato_id);
                PlayerPrefs.SetString("usuario_nombre", inputNombre.text);

                SceneManager.LoadScene(data.gato_id == 0 ? "SeleccionAvatar" : "MenuPrincipal");
            }
        }
        else
        {
            mensaje.text = "Error de red: " + www.error;
        }
    }
}