using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int maxVida = 3;
    public int vidaActual;
    public Transform puntoRespawn;
    public float tiempoInven = 1f;
    [HideInInspector] public bool invencible = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start()
    {
        vidaActual = maxVida;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void perderVida()
    {
        if (invencible) return;

        vidaActual--;

        // 🔹 Actualizar barra de vida inmediatamente
        BarraDeVida barra = Object.FindAnyObjectByType<BarraDeVida>();
        if (barra != null)
            barra.ActualizarBarra();

        if (vidaActual > 0)
        {
            Respawnear();
        }
        else
        {
            GameOver();
        }
    }

    public void Respawnear()
    {
        transform.position = puntoRespawn.position;
        rb.linearVelocity = Vector2.zero;
        StartCoroutine(InvencibilidadTemporal());
    }

    private IEnumerator InvencibilidadTemporal()
    {
        invencible = true;
        float tiempo = 0f;

        while (tiempo < tiempoInven)
        {
            sprite.enabled = !sprite.enabled;
            tiempo += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        sprite.enabled = true;
        invencible = false;
    }

    public void ActivarInvencibilidad()
    {
        StartCoroutine(InvencibilidadTemporal());
    }

    private void GameOver()
    {
        SceneManager.LoadScene("gameOver");
    }
}