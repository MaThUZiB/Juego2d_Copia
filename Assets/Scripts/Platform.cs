using UnityEngine;

public class PlataformaMovimientoVertical : MonoBehaviour
{
    public float velocidad = 2f;       // Velocidad de movimiento
    public float distancia = 3f;       // Distancia máxima desde la posición inicial
    public bool empiezaHaciaArriba = true; // Dirección inicial del movimiento

    private Vector3 posicionInicial;
    private int direccion; // 1 = hacia arriba, -1 = hacia abajo

    void Start()
    {
        posicionInicial = transform.position;
        direccion = empiezaHaciaArriba ? 1 : -1;
    }

    void Update()
    {
        // Movimiento vertical
        transform.Translate(Vector2.up * direccion * velocidad * Time.deltaTime);

        // Cambiar dirección cuando llega al límite
        if (transform.position.y >= posicionInicial.y + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.y <= posicionInicial.y - distancia)
        {
            direccion = 1;
        }
    }

    // Para que el jugador se "pegue" a la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // Para que el jugador se "despegue" al salir
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}