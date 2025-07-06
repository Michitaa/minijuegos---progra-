using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class SeleccionAvatar : MonoBehaviour
{
    [Header("Prefabs de los gatos")]
    public GameObject[] prefabsGatos;

    [Header("Transform donde se mostrará el gato seleccionado")]
    public Transform previewContenedor;

    [Header("Nombre de la escena siguiente")]
    public string escenaSiguiente = "MenuPrincipal";

    private int gatoSeleccionado = 1;
    private GameObject previewActual;

    public void SeleccionarGato(int gatoID)
    {
        gatoSeleccionado = gatoID;

        // Destruir preview anterior si existe
        if (previewActual != null)
            Destroy(previewActual);

        // Instanciar nuevo gato
        GameObject prefab = prefabsGatos[gatoID - 1];
        previewActual = Instantiate(prefab, previewContenedor.position, previewContenedor.rotation, previewContenedor);
    }

    public void ConfirmarSeleccion()
    {
        StartCoroutine(GuardarAvatarEnServidor());
    }

    IEnumerator GuardarAvatarEnServidor()
    {
        int usuarioID = PlayerPrefs.GetInt("usuario_id", -1);
        if (usuarioID == -1)
        {
            Debug.LogError("No se encontró el usuario_id");
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("usuario_id", usuarioID);
        form.AddField("gato_id", gatoSeleccionado);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego/actualizar_avatar.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Gato actualizado");
            PlayerPrefs.SetInt("gato_id", gatoSeleccionado);
            SceneManager.LoadScene(escenaSiguiente);
        }
        else
        {
            Debug.LogError("Error: " + www.error);
        }
    }
}
