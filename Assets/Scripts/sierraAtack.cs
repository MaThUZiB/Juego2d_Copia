using UnityEngine;

public class sierraAtack : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vida vidaJugador = collision.GetComponent<Vida>();

            if (vidaJugador != null)
            {
                for (int i = 0; i < damage; i++)
                    vidaJugador.perderVida();
            }
        }
    } 
}
