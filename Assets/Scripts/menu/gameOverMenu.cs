using UnityEngine;
using UnityEngine.SceneManagement;


public class gameOverMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Reintentar()
    {
        SceneManager.LoadScene("nivel1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
