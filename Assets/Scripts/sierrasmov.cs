using UnityEngine;

public class SierraMovimiento : MonoBehaviour
{
    public float velocidad = 2f;       // Velocidad del movimiento
    public float distancia = 3f;       // Qué tan alto/bajo se moverá
    public bool empiezaHaciaArriba = true; // Cambia esto en el Inspector para invertir el inicio

    private Vector3 posicionInicial;
    private int direccion; // 1 = arriba, -1 = abajo

    void Start()
    {
        posicionInicial = transform.position;
        direccion = empiezaHaciaArriba ? 1 : -1;
    }

    void Update()
    {
        // Movimiento solo en Y
        transform.Translate(Vector2.up * direccion * velocidad * Time.deltaTime);

        // Si la sierra alcanza el límite superior o inferior, cambia de dirección
        if (transform.position.y >= posicionInicial.y + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.y <= posicionInicial.y - distancia)
        {
            direccion = 1;
        }
    }
}
