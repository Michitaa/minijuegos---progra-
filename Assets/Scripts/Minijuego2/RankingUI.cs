using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class RankingUI : MonoBehaviour
{
    public TMP_Text textoRanking;
    
   
    public void MostrarRankingPorMinijuego(int minijuegoID)
    {
        StartCoroutine(ObtenerRanking("http://localhost/juego/ranking_por_minijuego.php", minijuegoID));
    }

    public void MostrarRankingGeneral()
    {
        StartCoroutine(ObtenerRanking("http://localhost/juego/ranking_general.php", -1));
    }

    IEnumerator ObtenerRanking(string url, int minijuegoID)
    {
        WWWForm form = new WWWForm();
        if (minijuegoID != -1)
            form.AddField("minijuego_id", minijuegoID);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Respuesta servidor: " + www.downloadHandler.text);
            RankingModel ranking = JsonUtility.FromJson<RankingModel>(www.downloadHandler.text);

            if (ranking != null && ranking.data.Length > 0)
            {
                textoRanking.text = "🏆 Ranking 🏆\n";
                int posicion = 1;
                foreach (RankingItem item in ranking.data)
                {
                    textoRanking.text += $"{posicion++}. {item.nombre}: {item.puntos} pts\n";
                }
            }
            else
            {
                textoRanking.text = "No hay datos de ranking.";
            }
        }
        else
        {
            textoRanking.text = "Error al cargar el ranking.";
            Debug.LogError(www.error);
        }
    }
}