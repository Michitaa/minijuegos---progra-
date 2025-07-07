using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MemoriaGameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    public List<Sprite> imagenes;
    public Transform tablero;

    private List<CartaMemoria> cartas;
    private CartaMemoria cartaA;
    private CartaMemoria cartaB;
    private int aciertos = 0;

    void Start()
    {
        GenerarCartas();
    }

    void GenerarCartas()
    {
        cartas = new List<CartaMemoria>();
        List<Sprite> duplicadas = new List<Sprite>(imagenes);
        duplicadas.AddRange(imagenes); // pares

        for (int i = 0; i < duplicadas.Count; i++)
        {
            GameObject obj = Instantiate(cartaPrefab, tablero);
            CartaMemoria carta = obj.AddComponent<CartaMemoria>();
            carta.id = i / 2;
            carta.frente = duplicadas[i];
            cartas.Add(carta);
        }

        cartas = Barajar(cartas);
    }

    List<CartaMemoria> Barajar(List<CartaMemoria> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            CartaMemoria temp = lista[i];
            int randomIndex = Random.Range(0, lista.Count);
            lista[i] = lista[randomIndex];
            lista[randomIndex] = temp;
        }
        return lista;
    }

    public void SeleccionarCarta(CartaMemoria carta)
    {
        if (cartaA == null)
        {
            cartaA = carta;
            cartaA.Voltear();
        }
        else if (cartaB == null && carta != cartaA)
        {
            cartaB = carta;
            cartaB.Voltear();
            StartCoroutine(CompararCartas());
        }
    }

    IEnumerator CompararCartas()
    {
        yield return new WaitForSeconds(1f);
        if (cartaA.id == cartaB.id)
        {
            aciertos++;
            cartaA.MostrarCorrecta();
            cartaB.MostrarCorrecta();
        }
        else
        {
            cartaA.OcultarIncorrecta();
            cartaB.OcultarIncorrecta();
        }

        cartaA = null;
        cartaB = null;

        if (aciertos == imagenes.Count)
        {
            PlayerPrefs.SetInt("puntaje_memoria", aciertos);
            SceneManager.LoadScene("VictoriaMemoria");
        }
    }
}
