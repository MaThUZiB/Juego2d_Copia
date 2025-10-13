using UnityEngine;

public class AtaqueBoss : MonoBehaviour
{
    public int damage = 1;
    private bool yaGolpeo = false;

    private void OnEnable()
    {
        yaGolpeo = false; // Reset cada vez que el hitbox se activa
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (yaGolpeo) return;

        if (collision.CompareTag("Player"))
        {
            Vida vidaJugador = collision.GetComponent<Vida>();
            if (vidaJugador != null && !vidaJugador.invencible)
            {
                vidaJugador.perderVida();            // Quita 1 vida
                vidaJugador.ActivarInvencibilidad(); // Activa invencibilidad temporal
                yaGolpeo = true;                     // Solo daño una vez por ataque
            }
        }
    }
}
