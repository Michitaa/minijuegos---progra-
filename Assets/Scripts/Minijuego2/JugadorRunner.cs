using UnityEngine;

public class JugadorRunner : MonoBehaviour
{
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            enSuelo = true;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ScoreManagerRunner.instance.PerderVida(); 
        }
    }
}