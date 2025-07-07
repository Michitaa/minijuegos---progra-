using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
{
    float h = Input.GetAxis("Horizontal");
    Vector3 posicion = transform.position;
    posicion.x += h * velocidad * Time.deltaTime;

    
    posicion.x = Mathf.Clamp(posicion.x, -15f, 15f);

    transform.position = posicion;
}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(h, 0, 0);
        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            ScoreManager.instance.PerderVida();
        }
    }
}