using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Enemigo")]
    public float velocidad = 3f;          // Velocidad de movimiento
    public float distanciaAtaque = 1.5f;  // Distancia mínima para atacar
    public int daño = 10;                 // Daño al jugador

    private Transform jugador;
    private Rigidbody2D rb;
    private bool atacando = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Busca al jugador en la escena (asegúrate que tenga tag "Player")
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            jugador = playerObj.transform;
        else
            Debug.LogError("No se encontró un objeto con tag 'Player'");
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
            atacando = false;
        }
        else
        {
            // Detener movimiento y atacar
            rb.linearVelocity = Vector2.zero;
            if (!atacando)
            {
                atacando = true;
                Atacar();
            }
        }
    }

    void Atacar()
    {
        // Aquí puedes llamar a un método del jugador para quitarle vida
        Debug.Log("¡Atacando al jugador! Daño: " + daño);

        // Si tienes un script de jugador con un método TakeDamage(int dmg)
        // jugador.GetComponent<MovimientoPersonaje>().TakeDamage(daño);

        // Ejemplo simple: solo mensaje por ahora
    }
}