using UnityEngine;

public class SierraMovimientoHorizontal : MonoBehaviour
{
    public float velocidad = 2f;        
    public float distancia = 3f;        
    public bool empiezaHaciaDerecha = true; 

    private Vector3 posicionInicial;
    private int direccion; 
    void Start()
    {
        posicionInicial = transform.position;
        direccion = empiezaHaciaDerecha ? 1 : -1;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);
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
