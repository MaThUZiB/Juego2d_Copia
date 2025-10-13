using UnityEngine;

public class SierraMovimiento : MonoBehaviour
{
    public float velocidad = 2f;       
    public float distancia = 3f;       
    public bool empiezaHaciaArriba = true; 
    private Vector3 posicionInicial;
    private int direccion; 

    void Start()
    {
        posicionInicial = transform.position;
        direccion = empiezaHaciaArriba ? 1 : -1;
    }

    void Update()
    {
        transform.Translate(Vector2.up * direccion * velocidad * Time.deltaTime);
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
