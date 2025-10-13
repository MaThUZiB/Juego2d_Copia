using UnityEngine;
using UnityEngine.UI;

public class UIVida : MonoBehaviour
{
    public Vida jugador;
    public Image[] corazones;
    public Sprite corazonLleno;
    public Sprite corazonVacio;


    // Update is called once per frame
    void Update()
    {
        ActualizarCorazones();        
    }

    void ActualizarCorazones() {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < jugador.vidaActual)
                corazones[i].sprite = corazonLleno;
            else
                corazones[i].sprite = corazonVacio;
        }
    }
}
