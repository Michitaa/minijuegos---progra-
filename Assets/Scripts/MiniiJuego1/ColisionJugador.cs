using UnityEngine;

public class ColisionJugador : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.PerderVida();
        }
    }
}
