using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Configuración del Enemigo")]
    public float velocidad = 3f;          // Velocidad de movimiento
    public float distanciaAtaque = 1.5f;  // Distancia mínima para atacar
    public int daño = 1;                  // Cuánta vida quita al jugador
    public float tiempoEntreAtaques = 1f; // Tiempo de espera entre ataques

    private Transform jugador;
    private Rigidbody2D rb;
    private bool puedeAtacar = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Busca al jugador (asegúrate que tenga el tag "Player")
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            jugador = playerObj.transform;
        else
            Debug.LogError("⚠️ No se encontró un objeto con tag 'Player'");
    }

    void FixedUpdate()
    {
        if (jugador == null) return;

        // Calcula la distancia al jugador
        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia > distanciaAtaque)
        {
            // Moverse hacia el jugador
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.linearVelocity = direccion * velocidad;
        }
        else
        {
            // Detener movimiento
            rb.linearVelocity = Vector2.zero;

            // Intentar atacar si se puede
            if (puedeAtacar)
            {
                StartCoroutine(Atacar());
            }
        }
    }

    private System.Collections.IEnumerator Atacar()
    {
        puedeAtacar = false;

        if (jugador != null)
        {
            Vida vidaJugador = jugador.GetComponent<Vida>();
            if (vidaJugador != null && !vidaJugador.invencible)
            {
                vidaJugador.perderVida();
            }
        }

        // Espera un tiempo antes de volver a atacar
        yield return new WaitForSeconds(tiempoEntreAtaques);
        puedeAtacar = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si quieres que también cause daño al chocar físicamente
        if (collision.gameObject.CompareTag("Player"))
        {
            Vida vidaJugador = collision.gameObject.GetComponent<Vida>();
            if (vidaJugador != null && !vidaJugador.invencible)
            {
                vidaJugador.perderVida();
            }
        }
    }
}