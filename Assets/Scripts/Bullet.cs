using UnityEngine; 

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f; // tiempo en segundos antes de destruir la bala
    public float damage = 10f;

    private void Start()
    {
        // Destruye la bala automáticamente después de 'lifetime' segundos
        Destroy(gameObject, lifetime);
    } 

    private void Update()
    {
        // Mueve la bala hacia adelante
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si colisiona con el boss
        if (collision.CompareTag("Boss"))
        {
            boss bossScript = collision.GetComponent<boss>();
            if (bossScript != null)
                bossScript.TomarDamage(damage);
        }

        // Destruye la bala al colisionar con cualquier cosa
        Destroy(gameObject);
    }
}
