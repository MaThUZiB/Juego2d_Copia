using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    [Header("Componentes")]
    private Animator animator;
    private Rigidbody2D rb;
    public Transform jugador;
    private bool mirandoDer = true;

    [Header("Vida del Boss")]
    [SerializeField] private float vida = 100f;
    [SerializeField] private BarraDeVida barraDeVida;

    [Header("Movimiento y Ataque")]
    public float rangoDeteccion = 8f;
    public float rangoAtaque = 2f;
    public float velocidad = 2f;
    public float tiempoEntreAtaques = 2f;

    private bool puedeAtacar = true;

    [Header("Hitbox Ataque")]
    public GameObject hitBoxAtaque; // Asignar el HitBoxAtaque en el Inspector

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
    }

    private void Update()
    {
        if (jugador == null) return;

        MirarJugador();

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Movimiento hacia el jugador
        if (distancia <= rangoDeteccion && distancia > rangoAtaque)
        {
            animator.SetBool("Caminando", true);
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direccion.x * velocidad, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("Caminando", false);
        }

        // Ataque
        if (distancia <= rangoAtaque && puedeAtacar)
        {
            StartCoroutine(Atacar());
        }
    }

    private IEnumerator Atacar()
    {
        puedeAtacar = false;
        animator.SetBool("Caminando", false);

        // Elegir Ataque1 o Ataque2 aleatoriamente
        int tipoAtaque = Random.Range(0, 2);
        if (tipoAtaque == 0) animator.SetTrigger("Ataque1");
        else animator.SetTrigger("Ataque2");

        // Espera duración de ataque para no interrumpir animación
        yield return new WaitForSeconds(tiempoEntreAtaques);
        puedeAtacar = true;

        // Reset triggers para evitar quedarse pegado
        animator.ResetTrigger("Ataque1");
        animator.ResetTrigger("Ataque2");
    }

    public void TomarDamage(float damage)
    {
        vida -= damage;
        barraDeVida.CambiarVidaActual(vida);

        if (vida <= 0)
        {
            animator.SetTrigger("Muerte");
            rb.linearVelocity = Vector2.zero;
            this.enabled = false;
            StartCoroutine(cambioEscena());
            
            
        }
        else
        {
            StartCoroutine(ParpadeoDaño());
        }
    }

    private IEnumerator cambioEscena ()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("completado");
        Destroy(gameObject, 1f);
    }

    private IEnumerator ParpadeoDaño()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    // Llamadas desde Animation Events
    public void ActivarHitBox()
    {
        if(hitBoxAtaque != null) hitBoxAtaque.SetActive(true);
    }

    public void DesactivarHitBox()
    {
        if(hitBoxAtaque != null) hitBoxAtaque.SetActive(false);
    }

    private void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDer) ||
            (jugador.position.x < transform.position.x && mirandoDer))
        {
            mirandoDer = !mirandoDer;
            transform.Rotate(0, 180f, 0);
        }
    }
}
