using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EliminarPuntajemini1 : MonoBehaviour
{
  public void OnEliminarPuntajeClick()
    {
        StartCoroutine(EliminarPuntaje());
    }

    IEnumerator EliminarPuntaje()
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario_id", PlayerPrefs.GetInt("usuario_id")); // Ya deberías tenerlo guardado
        form.AddField("minijuegos_id", 1); // Aquí pones el ID del minijuego que deseas eliminar

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego/eliminar_puntaje.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error al eliminar puntaje: " + www.error);
            }
        }
    }
}
