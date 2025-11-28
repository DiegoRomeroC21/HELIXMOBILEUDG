using UnityEngine;
using UnityEngine.SceneManagement;

public class Changes : MonoBehaviour
{
    // Llamar desde el botón "Volver"
    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }
}