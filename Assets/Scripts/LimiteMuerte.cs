using UnityEngine;

public class LimiteMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Vida vida = other.GetComponent<Vida>();
            if (vida != null) {
                vida.perderVida();
            }
        }
    }
}
