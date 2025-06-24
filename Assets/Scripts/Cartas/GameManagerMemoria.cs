using System.Collections;
using UnityEngine;
public class GameManagerMemoria : MonoBehaviour
{
    public static GameManagerMemoria Instance;

    private CartaInteractiva primeraCarta;
    private CartaInteractiva segundaCarta;
    private bool esperando = false;

    void Awake()
    {
        Instance = this;
    }

    public void CartaRevelada(CartaInteractiva carta)
    {
        if (esperando || carta.EstaRevelada() == false)
            return;

        if (primeraCarta == null)
        {
            primeraCarta = carta;
        }
        else if (segundaCarta == null && carta != primeraCarta)
        {
            segundaCarta = carta;
            StartCoroutine(CompararCartas());
        }
    }

    IEnumerator CompararCartas()
    {
        esperando = true;
        yield return new WaitForSeconds(1f);  

        if (primeraCarta.tipoCarta == segundaCarta.tipoCarta)
        {
 
        }
        else
        {  
            primeraCarta.Ocultar();
            segundaCarta.Ocultar();
        }

        primeraCarta = null;
        segundaCarta = null;
        esperando = false;
    }
}