using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Plataforma2 : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 2f;          // Velocidad de movimiento
    public float distancia = 3f;          // Distancia máxima desde la posición inicial
    public bool empiezaHaciaArriba = true;

    private Vector3 posicionInicial;
    private int direccion; // 1 = hacia arriba, -1 = hacia abajo
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // importante: que no sea afectado por física
        posicionInicial = transform.position;
        direccion = empiezaHaciaArriba ? 1 : -1;
    }

    void FixedUpdate()
    {
        // Movimiento vertical usando MovePosition (mejor para colisiones)
        Vector2 nuevaPos = rb.position + Vector2.up * direccion * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(nuevaPos);

        // Cambiar dirección al alcanzar límites
        if (transform.position.y >= posicionInicial.y + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.y <= posicionInicial.y - distancia)
        {
            direccion = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Solo se pega si el jugador está sobre la plataforma
            ContactPoint2D contacto = collision.contacts[0];
            if (contacto.normal.y > 0.5f)
            {
                collision.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}