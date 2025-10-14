using UnityEngine;

public class Puas : MonoBehaviour
{
    public int dano = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vida vida = collision.GetComponent<Vida>();
            if (vida != null)
            {
                vida.perderVida(); // 👈 usa tu método correcto
            }
        }
    }
}