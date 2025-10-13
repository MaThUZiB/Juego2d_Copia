using UnityEngine;
using UnityEngine.SceneManagement;


public class menuss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void iniciar () {
        SceneManager.LoadScene("nivel1");
   }

   public void seleccionNivel () {
        SceneManager.LoadScene("seleccionNivel");
   }

    public void salir () {
        Debug.Log("boton salir");
        Application.Quit();
   }
}
