using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int puntaje = 0;
    public int vidas = 1;
    public TMP_Text textoPuntaje;
    public TMP_Text textoVidas;
    public float tiempoEntrePuntos = 1f;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ActualizarUI();
        InvokeRepeating("SumarPuntosAutomaticos", tiempoEntrePuntos, tiempoEntrePuntos);
    }

    void SumarPuntosAutomaticos()
    {
        SumarPuntos(1); 
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        ActualizarUI();
    }

    public void PerderVida()
    {
        vidas--;
        ActualizarUI();

        if (vidas <= 0)
        {
            PlayerPrefs.SetInt("ultimo_puntaje", puntaje);
            PlayerPrefs.Save(); 
            SceneManager.LoadScene("Derrota");
        }
    }

    void ActualizarUI()
    {
        textoPuntaje.text = "Puntaje: " + puntaje;
        textoVidas.text = "Vidas: " + vidas;
    }
}