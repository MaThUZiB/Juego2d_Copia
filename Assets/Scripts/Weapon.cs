using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Disparo")]
    public Transform firePoint;      
    public GameObject bulletPrefab;  
    public float bulletForce = 20f;  

    [Header("Audio")]
    public AudioClip sonidoDisparo;  
    [Range(0f, 1f)] public float volumenDisparo = 0.5f; 

    public void OnAttack()
    {
        if (bulletPrefab == null || firePoint == null)
            return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float direccion = Mathf.Sign(transform.localScale.x); 
            rb.linearVelocity = Vector2.right * bulletForce * direccion;
        }

        if (sonidoDisparo != null)
        {
            
            GameObject tempAudio = new GameObject("disparoTemp");
            AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
            audioSource.clip = sonidoDisparo;
            audioSource.volume = volumenDisparo;
            audioSource.spatialBlend = 0f; 
            audioSource.Play();
            Destroy(tempAudio, sonidoDisparo.length);
        }
    }
}
