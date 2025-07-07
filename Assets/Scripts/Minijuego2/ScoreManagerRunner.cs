using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManagerRunner : MonoBehaviour
{
   public static ScoreManagerRunner instance;

    public int puntaje = 0;
    public int vidas = 1;
    public TMP_Text textoPuntaje;
    public TMP_Text textoVidas;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        InvokeRepeating("AumentarPuntaje", 1f, 1f);
        ActualizarUI();
    }

    void AumentarPuntaje()
    {
        puntaje++;
        ActualizarUI();
    }

    public void PerderVida()
    {
        vidas--;
        ActualizarUI();
        if (vidas <= 0)
        {
            PlayerPrefs.SetInt("puntaje_minijuego", puntaje);
            PlayerPrefs.SetInt("minijuego_actual", 2); 
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
