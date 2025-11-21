using UnityEngine;
using UnityEngine.InputSystem;

public class HelixControl : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startPosition;
    private Mouse mouse;

    void Start()
    {
        startPosition = transform.localEulerAngles;
        mouse = Mouse.current;  // Obtener la entrada del ratón
    }

    void Update()
    {
        if (mouse.leftButton.isPressed) // Verificar si el botón izquierdo está presionado
        {
            Vector2 currentTapPosition = mouse.position.ReadValue(); // Leer la posición del ratón

            if (lastTapPosition == Vector2.zero)
            {
                lastTapPosition = currentTapPosition;
            }

            float distance = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition = currentTapPosition;

            transform.Rotate(Vector3.up, -distance); // Girar el objeto
        }

        if (!mouse.leftButton.isPressed) // Si el botón izquierdo se ha soltado
        {
            lastTapPosition = Vector2.zero;
        }
    }
}
