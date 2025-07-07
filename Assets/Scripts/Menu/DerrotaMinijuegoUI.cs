using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class DerrotaMinijuegoUI : MonoBehaviour
{
    public TMP_Text textoPuntaje;
    public Button botonVolver;

    void Start()
    {
        int puntaje = PlayerPrefs.GetInt("ultimo_puntaje", 0);
        textoPuntaje.text = "Tu puntaje: " + puntaje;

        // Enviar el puntaje al servidor
        StartCoroutine(EnviarPuntaje(puntaje));

        // Asignar evento al botón
        botonVolver.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MenuPrincipal");
        });
    }

    IEnumerator EnviarPuntaje(int puntaje)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario_id", PlayerPrefs.GetInt("usuario_id"));
        form.AddField("minijuegos_id", 1); // ID del minijuego
        form.AddField("puntos", puntaje);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego/gestionar_score.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Respuesta: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error al enviar puntaje: " + www.error);
            }
        }
    }
}