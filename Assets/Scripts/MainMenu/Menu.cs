using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void EmpezarElJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    // nueva: abrir la escena "Cambios Originales" (build index 2)
    public void AbrirCambiosOriginales()
    {
        SceneManager.LoadScene(2);
    }
}
