using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuBotones : MonoBehaviour
{
    public void IrAMemoria()
    {
        SceneManager.LoadScene("MinijuegoMemoria");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
