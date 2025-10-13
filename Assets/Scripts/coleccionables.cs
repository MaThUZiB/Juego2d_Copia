using UnityEngine;
using UnityEngine.UI;

public class coleccionables : MonoBehaviour
{
    public static int cantidadcoleccionables = 0;

    [Header("UI")]
    [SerializeField] private Text textCollection;

    [Header("Audio")]
    public AudioClip sonidoPickup; 
    [Range(0f, 1f)] public float volumenPickup = 0.6f; 

    void Start()
    {
        cantidadcoleccionables = 0;
        if (textCollection != null)
            textCollection.text = "0/10";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("manzana"))
        {
            if (sonidoPickup != null)
            {
                GameObject tempAudio = new GameObject("pickupTemp");
                AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
                audioSource.clip = sonidoPickup;
                audioSource.volume = volumenPickup;
                audioSource.spatialBlend = 0f; 
                audioSource.Play();
                Destroy(tempAudio, sonidoPickup.length);
            }

            cantidadcoleccionables++;
            if (textCollection != null)
                textCollection.text = cantidadcoleccionables + "/10";

            Destroy(collision.gameObject);
        }
    }
}
