using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuBotones : MonoBehaviour
{
    public void IrAObstaculos()
    {
        SceneManager.LoadScene("Obstaculos");
    }

     public void IrARunner()
    {
        SceneManager.LoadScene("Salto");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void IrARanking()
    {
        SceneManager.LoadScene("Ranking");
    }
    
     public void IrAMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
