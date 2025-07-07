using UnityEngine;

[System.Serializable]
public class CartaBase : MonoBehaviour
{
    public int id;
    public bool estaVolteada = false;

    public virtual void Voltear() { }
}