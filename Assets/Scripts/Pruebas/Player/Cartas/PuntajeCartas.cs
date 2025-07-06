using TMPro;
using UnityEngine;

public class PuntajeCartas : MonoBehaviour
{
   [SerializeField] private int puntaje;
   [SerializeField] private Canvas canvas;
   [SerializeField] private TextMeshProUGUI textpuntaje;

    void Start()
    {
           puntaje = 0;
    }


   
    public void SumandoPuntos()
    {
        puntaje ++;
        textpuntaje.text = $"Peces obtenidos: {puntaje}";
    }
}
