using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuBotones : MonoBehaviour
{
    public void IrAObstaculos()
    {
        SceneManager.LoadScene("Obstaculos");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
