using UnityEngine;

public class Sistemapreguntas : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen;

    public void AbrirPanel()
    {
        if (panelToOpen != null)
        {
            panelToOpen.SetActive(true);
        }
    }

    // Nuevo método para cerrar el panel
    public void CerrarPanel()
    {
        if (panelToOpen != null)
        {
            panelToOpen.SetActive(false);
        }
    }
}

