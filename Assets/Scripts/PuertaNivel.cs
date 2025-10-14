using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener índice de la escena actual
            int escenaActual = SceneManager.GetActiveScene().buildIndex;

            // Calcular índice del siguiente nivel
            int siguienteEscena = escenaActual + 1;

            // Verificar si existe siguiente escena en Build Settings
            if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(siguienteEscena);
            }
            else
            {
                // Si no hay más niveles, opcional: volver al primero o a escena de "Game Completed"
                SceneManager.LoadScene(0); // vuelve al primer nivel
                // SceneManager.LoadScene("gameCompleted"); // o cargar escena de final
            }
        }
    }
}