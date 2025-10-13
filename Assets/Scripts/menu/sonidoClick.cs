using UnityEngine;

public class sonidoClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonido;

    public void ReproducirSonido(){
        audioSource.PlayOneShot(sonido);
    }
}
