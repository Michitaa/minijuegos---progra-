using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{   public void ReiniciarNivel()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SeleccionarNivel()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void SeleccionarAvatar()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void IniciarSesion()
    {
        SceneManager.LoadScene("Cuenta");
    }

    public void Salir()
    {
        Application.Quit();
    } 
}