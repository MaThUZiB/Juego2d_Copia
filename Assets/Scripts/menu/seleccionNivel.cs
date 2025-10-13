using UnityEngine;
using UnityEngine.SceneManagement;


public class seleccionNivel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void nivel1()
    {
        SceneManager.LoadScene("nivel1");
    }

    public void nivel2()
    {
        SceneManager.LoadScene("nivel2");
    }

    public void nivel3()
    {
        SceneManager.LoadScene("nivel3");
    }

    public void nivel4()
    {
        SceneManager.LoadScene("nivel4");
    }
    public void nivel5()
    {
        SceneManager.LoadScene("nivel5");
    }

    public void volver()
    {
        SceneManager.LoadScene("Menu");
    }
}