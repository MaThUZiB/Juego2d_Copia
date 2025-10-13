using UnityEngine; 

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f; 
    public float damage = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    } 

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            boss bossScript = collision.GetComponent<boss>();
            if (bossScript != null)
                bossScript.TomarDamage(damage);
        }
        Destroy(gameObject);
    }
}
