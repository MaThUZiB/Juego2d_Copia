using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Image barraRelleno;
    private float vidaMaxima;

    public void InicializarBarraDeVida(float vida)
    {
        vidaMaxima = vida;
        barraRelleno.fillAmount = 1f; // llena la barra completamente
    }

    public void CambiarVidaActual(float vidaActual)
    {
        barraRelleno.fillAmount = vidaActual / vidaMaxima;
    }
}
