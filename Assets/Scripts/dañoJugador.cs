using UnityEngine;

public class dañoJugador : MonoBehaviour
{
    public int daño = 1; // Cuánta vida quita
    public bool usarTrigger = true; // Puedes cambiarlo si usas colisiones físicas

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!usarTrigger) return; // Solo se ejecuta si es trigger
        if (other.CompareTag("Player"))
        {
            Vida vida = other.GetComponent<Vida>();
            if (vida != null)
            {
                vida.perderVida();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (usarTrigger) return; // Solo se ejecuta si no es trigger
        if (collision.gameObject.CompareTag("Player"))
        {
            Vida vida = collision.gameObject.GetComponent<Vida>();
            if (vida != null)
            {
                vida.perderVida();
            }
        }
    }
}