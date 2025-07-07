using UnityEngine;

public class CartaMemoria : CartaBase
{
    public Sprite frente;
    public Sprite dorso;
    private SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = dorso;
    }

    public override void Voltear()
    {
        estaVolteada = !estaVolteada;
        render.sprite = estaVolteada ? frente : dorso;
    }

    public void MostrarCorrecta()
    {
        render.color = Color.green;
    }

    public void OcultarIncorrecta()
    {
        render.color = Color.red;
        Invoke("Voltear", 0.5f);
    }
}
