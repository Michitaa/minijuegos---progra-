using UnityEngine;

public class CamaraPrimeraPersona : MonoBehaviour
{
    public float sensibilidadMouse = 100f;
    public Transform cuerpoJugador;

    float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}
