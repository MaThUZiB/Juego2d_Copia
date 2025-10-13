using UnityEngine;

public class escotillaController : MonoBehaviour
{
    public int cantidadNecesaria = 10;
    public Vector3 direccionMovimiento = new Vector3(1f, 0f, 0f); // mover a la derecha
    public float distancia = 2f; // cuánto se mueve
    public float duracion = 1f; // tiempo en segundos

    private bool activada = false;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (!activada && coleccionables.cantidadcoleccionables >= cantidadNecesaria)
        {
            AbrirEscotilla();
        }
    }

    void AbrirEscotilla()
    {
        activada = true;
        StartCoroutine(MoverEscotilla());
    }

    private System.Collections.IEnumerator MoverEscotilla()
    {
        Vector3 destino = posicionInicial + direccionMovimiento.normalized * distancia;
        float tiempo = 0f;

        // Desactivar el collider antes de mover si quieres que el jugador pueda pasar mientras se mueve
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (col != null) col.isTrigger = true;

        while (tiempo < duracion)
        {
            transform.position = Vector3.Lerp(posicionInicial, destino, tiempo / duracion);
            tiempo += Time.deltaTime;
            yield return null;
        }

        transform.position = destino;
    }
}
