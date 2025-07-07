using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class MemoriaScoreManager : MonoBehaviour
{
    private const string baseUrl = "http://localhost/juego/"; 
    public int minijuegoId = 1; // ID del minijuego de memoria

    public void InsertarPuntaje(int usuarioId, int puntos, Action<string> onResult)
    {
        StartCoroutine(Enviar("insertar_puntaje_memoria.php", usuarioId, puntos, onResult));
    }

    public void ObtenerPuntaje(int usuarioId, Action<int> onResult)
    {
        StartCoroutine(EnviarConsulta("obtener_puntaje_memoria.php", usuarioId, onResult));
    }

    public void ActualizarPuntaje(int usuarioId, int puntos, Action<string> onResult)
    {
        StartCoroutine(Enviar("actualizar_puntaje_memoria.php", usuarioId, puntos, onResult));
    }

    public void EliminarPuntaje(int usuarioId, Action<string> onResult)
    {
        StartCoroutine(Eliminar("eliminar_puntaje_memoria.php", usuarioId, onResult));
    }

    IEnumerator Enviar(string archivo, int usuarioId, int puntos, Action<string> onResult)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario_id", usuarioId);
        form.AddField("minijuegos_id", minijuegoId);
        form.AddField("puntos", puntos);

        UnityWebRequest www = UnityWebRequest.Post(baseUrl + archivo, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var json = www.downloadHandler.text;
            MensajeRespuesta respuesta = JsonUtility.FromJson<MensajeRespuesta>(json);
            onResult?.Invoke(respuesta.mensaje);
        }
        else
        {
            onResult?.Invoke("Error: " + www.error);
        }
    }

    IEnumerator EnviarConsulta(string archivo, int usuarioId, Action<int> onResult)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario_id", usuarioId);
        form.AddField("minijuegos_id", minijuegoId);

        UnityWebRequest www = UnityWebRequest.Post(baseUrl + archivo, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var json = www.downloadHandler.text;
            PuntajeRespuesta datos = JsonUtility.FromJson<PuntajeRespuesta>(json);
            onResult?.Invoke(datos.puntos);
        }
        else
        {
            Debug.LogError("Error al obtener puntaje: " + www.error);
        }
    }

    IEnumerator Eliminar(string archivo, int usuarioId, Action<string> onResult)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario_id", usuarioId);
        form.AddField("minijuegos_id", minijuegoId);

        UnityWebRequest www = UnityWebRequest.Post(baseUrl + archivo, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var json = www.downloadHandler.text;
            MensajeRespuesta respuesta = JsonUtility.FromJson<MensajeRespuesta>(json);
            onResult?.Invoke(respuesta.mensaje);
        }
        else
        {
            onResult?.Invoke("Error: " + www.error);
        }
    }
}

[Serializable]
public class MensajeRespuesta
{
    public bool success;
    public string mensaje;
}

[Serializable]
public class PuntajeRespuesta
{
    public bool success;
    public int puntos;
}
