using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Image barraRelleno;
    [SerializeField] private Vida jugador;
    private float vidaMaxima;

    void Start()
    {
        if (jugador == null)
            jugador = Object.FindAnyObjectByType<Vida>();

        if (jugador != null)
            vidaMaxima = jugador.maxVida;

        ActualizarBarra();
    }

    void Update()
    {
        ActualizarBarra();
    }

    public void ActualizarBarra()
    {
        if (jugador == null) return;

        float vidaActual = jugador.vidaActual;
        barraRelleno.fillAmount = Mathf.Clamp01((float)vidaActual / vidaMaxima);
    }

    // 🔹 Compatibilidad con boss.cs
    public void InicializarBarraDeVida(float valorInicial)
    {
        if (jugador != null)
        {
            jugador.vidaActual = Mathf.RoundToInt(valorInicial);
            ActualizarBarra();
        }
    }

    public void CambiarVidaActual(float nuevaVida)
    {
        if (jugador != null)
        {
            jugador.vidaActual = Mathf.RoundToInt(nuevaVida);
            ActualizarBarra();
        }
    }
}