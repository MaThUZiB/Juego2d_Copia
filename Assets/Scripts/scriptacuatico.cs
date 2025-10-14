using UnityEngine;
using UnityEngine.InputSystem;

public class scriptacuatico : MonoBehaviour
{
    [Header("Movimiento Acuático")]
    public float velocidadAgua = 5f;
    public float gravedadAgua = 0.3f;

    private Rigidbody2D rb;
    private Vector2 inputMovimiento;
    private bool enAgua = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
            Debug.LogError("¡Rigidbody2D no encontrado!");
    }

    private void FixedUpdate()
    {
        if (enAgua)
        {
            rb.gravityScale = gravedadAgua;
            // Movimiento libre en X e Y
            rb.linearVelocity = new Vector2(inputMovimiento.x * velocidadAgua, inputMovimiento.y * velocidadAgua);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    // Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovimiento = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("agua"))
            enAgua = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("agua"))
            enAgua = false;
    }
}