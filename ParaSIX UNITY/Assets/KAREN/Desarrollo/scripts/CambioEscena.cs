using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaConE : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string nombreEscena;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
