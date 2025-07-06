using UnityEngine;
using TMPro;

public class MostrarJugador : MonoBehaviour
{
    public GameObject[] prefabsGatos;
    public Transform spawnGato;
    public TMP_Text textoNombre;

    void Start()
    {
        int gatoID = PlayerPrefs.GetInt("gato_id", 1);
        int index = gatoID - 1;

        if (index >= 0 && index < prefabsGatos.Length)
        {
            Instantiate(prefabsGatos[index], spawnGato.position, spawnGato.rotation, spawnGato);
        }

        string nombre = PlayerPrefs.GetString("usuario_nombre", "Jugador");
        textoNombre.text = nombre;
    }
}
