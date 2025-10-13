using UnityEngine;

public class SierraMovimientoHorizontal : MonoBehaviour
{
    public float velocidad = 2f;        // Velocidad del movimiento
    public float distancia = 3f;        // Qué tan lejos se moverá a la izquierda/derecha
    public bool empiezaHaciaDerecha = true; // Cambia esto en el Inspector para invertir el inicio

    private Vector3 posicionInicial;
    private int direccion; // 1 = derecha, -1 = izquierda

    void Start()
    {
        posicionInicial = transform.position;
        direccion = empiezaHaciaDerecha ? 1 : -1;
    }

    void Update()
    {
        // Movimiento solo en X
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        // Si alcanza el límite derecho o izquierdo, cambia de dirección
        if (transform.position.x >= posicionInicial.x + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.x <= posicionInicial.x - distancia)
        {
            direccion = 1;
        }
    }
}
