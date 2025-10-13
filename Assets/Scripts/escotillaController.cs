using UnityEngine;

public class escotillaController : MonoBehaviour
{
    [Header("Configuración de apertura")]
    public int cantidadNecesaria = 10;
    public Vector3 direccionMovimiento = new Vector3(1f, 0f, 0f); 
    public float distancia = 2f; 
    public float duracion = 1f; 

    [Header("Audio")]
    public AudioClip sonidoApertura;
    [Range(0f, 1f)] public float volumen = 0.7f;

    private bool activada = false;
    private Vector3 posicionInicial;
    private AudioSource audioSource;

    void Start()
    {
        posicionInicial = transform.position;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
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
        if (sonidoApertura != null)
        {
            audioSource.PlayOneShot(sonidoApertura, volumen);
        }

        StartCoroutine(MoverEscotilla());
    }

    private System.Collections.IEnumerator MoverEscotilla()
    {
        Vector3 destino = posicionInicial + direccionMovimiento.normalized * distancia;
        float tiempo = 0f;
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
