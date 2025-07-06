using System.Collections.Generic;
using UnityEngine;

public class GeneradorCartas : MonoBehaviour
{
    public GameObject[] prefabsCartas;  
    public int cantidadPares = 3;
    public float separacion = 2f;  

    private List<GameObject> cartasInstanciadas = new List<GameObject>();

    void Start()
    {
        List<GameObject> listaCartas = new List<GameObject>();

        for (int i = 0; i < cantidadPares; i++)
        {
            listaCartas.Add(prefabsCartas[i]);
            listaCartas.Add(prefabsCartas[i]);
        }

        for (int i = 0; i < listaCartas.Count; i++)
        {
            int rand = Random.Range(i, listaCartas.Count);
            var temp = listaCartas[i];
            listaCartas[i] = listaCartas[rand];
            listaCartas[rand] = temp;
        }

        for (int i = 0; i < listaCartas.Count; i++)
        {
            Vector3 posicion = new Vector3(i * separacion, 3.3f, 0); // el numero dsp de separacion es para elevar
            GameObject carta = Instantiate(listaCartas[i], posicion, Quaternion.identity);
            cartasInstanciadas.Add(carta);
        }
    }
}