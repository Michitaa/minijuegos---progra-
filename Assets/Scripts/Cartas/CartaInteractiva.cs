using UnityEngine;

public class CartaInteractiva : MonoBehaviour
{
    public string tipoCarta;  
    public GameObject uiE;
    public Material materialDestapado;

    private bool jugadorCerca = false;
    private Renderer rend;
    private Material materialOriginal;
    private bool revelada = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        materialOriginal = rend.material;
        if (uiE != null)
            uiE.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E) && !revelada)
        {
            Revelar();
        }
    }

    public void Revelar()
    {
        revelada = true;
        rend.material = materialDestapado;
        if (uiE != null) uiE.SetActive(false);

        GameManagerMemoria.Instance.CartaRevelada(this);
    }

    public void Ocultar()
    {
        rend.material = materialOriginal;
        revelada = false;
    }

    public bool EstaRevelada()
    {
        return revelada;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            if (!revelada && uiE != null) uiE.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            if (uiE != null) uiE.SetActive(false);
        }
    }
}