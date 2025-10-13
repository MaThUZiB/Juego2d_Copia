using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPersonaje : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 10f;
    public float fuerzaSalto = 12f;
    public Transform chequeoSuelo;
    public float radioChequeo = 0.12f;
    public LayerMask capaSuelo;
    public float velocidadSubida = 4f;

    private Rigidbody2D rb;
    private SpriteRenderer spritePersonaje;
    private Animator animator;
    private Vector2 moveInput;
    private float movimientoVertical;
    private bool enSuelo;
    private bool enEscalera;
    private bool escalando;

    [Header("Arma")]
    public Transform weaponHolder;
    public GameObject startingWeapon;
    private GameObject currentWeapon;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spritePersonaje = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Equipar arma desde el inicio
        if (startingWeapon != null)
            EquipWeapon(startingWeapon);
    }

    private void FixedUpdate()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(moveInput.x * velocidad, rb.linearVelocity.y);
        animator.SetFloat("camina", Mathf.Abs(moveInput.x * velocidad));
        animator.SetBool("enSuelo", enSuelo);

        if(moveInput.x != 0)
        {
            float direccion = Mathf.Sign(moveInput.x);

            // Flip del sprite del personaje
            spritePersonaje.flipX = direccion < 0;

            // Flip del arma
            Vector3 armaScale = currentWeapon.transform.localScale;
            armaScale.x = Mathf.Abs(armaScale.x) * direccion; // mantiene posición relativa
            currentWeapon.transform.localScale = armaScale;

            // Opcional: ajustar rotación si el arma dispara con angulo
            currentWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0); 
        }
        // Escalera
        if (escalando)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, movimientoVertical * velocidadSubida);
        }
        else rb.gravityScale = 1f;

        // Suelo
        enSuelo = Physics2D.OverlapCircle(chequeoSuelo.position, radioChequeo, capaSuelo);
    }

    private void Update()
    {
        escalando = enEscalera && Mathf.Abs(movimientoVertical) > 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("escalera")) enEscalera = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("escalera")) enEscalera = false;
    }

    // Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = new Vector2(input.x, 0f);
        movimientoVertical = input.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && enSuelo)
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && currentWeapon != null)
        {
            Weapon weaponScript = currentWeapon.GetComponent<Weapon>();
            if (weaponScript != null) weaponScript.OnAttack();
        }
        Debug.Log("Disparo activado!");
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null) Destroy(currentWeapon);
        currentWeapon = Instantiate(weaponPrefab, weaponHolder.position, weaponHolder.rotation, weaponHolder);
    }
}
