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
        // Obtenemos datos guardados por el minijuego
        int puntaje = PlayerPrefs.GetInt("puntaje_minijuego", 0);
        int usuarioId = PlayerPrefs.GetInt("usuario_id", 0);
        int minijuegoId = PlayerPrefs.GetInt("minijuego_actual", 0);

        textoPuntaje.text = "Tu puntaje: " + puntaje;

        if (usuarioId > 0 && minijuegoId > 0)
        {
            StartCoroutine(EnviarPuntaje(usuarioId, minijuegoId, puntaje));
        }
        else
        {
            Debug.LogWarning("Faltan datos de usuario o minijuego.");
        }

        // Asignar evento al botón
        botonVolver.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MenuPrincipal");
        });
    }

    IEnumerator EnviarPuntaje(int usuarioId, int minijuegoId, int puntos)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario_id", usuarioId);
        form.AddField("minijuegos_id", minijuegoId);
        form.AddField("puntos", puntos);

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