using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Aqui se edita el Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody rb;
    private bool enSuelo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direccion = transform.right * x + transform.forward * z;
        Vector3 nuevaVelocidad = new Vector3(direccion.x * velocidad, rb.linearVelocity.y, direccion.z * velocidad);
        rb.linearVelocity = nuevaVelocidad;

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}