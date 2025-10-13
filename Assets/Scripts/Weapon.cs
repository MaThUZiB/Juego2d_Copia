using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;      // Punto de disparo
    public GameObject bulletPrefab;  // Prefab de la bala
    public float bulletForce = 20f;  // Velocidad de la bala

    public void OnAttack()
{
    if(bulletPrefab == null || firePoint == null) return;

    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    if(rb != null)
    {
        float direccion = Mathf.Sign(transform.localScale.x); // dirección según flip del arma
        rb.linearVelocity = Vector2.right * bulletForce * direccion;
    }
}



}
