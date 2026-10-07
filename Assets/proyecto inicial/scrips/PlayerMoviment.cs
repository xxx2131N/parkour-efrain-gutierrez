using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private float fuerzaSaltar = 7f;
    [SerializeField] private float peso = 5f;

    private Rigidbody rb;

    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = peso;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }

    void FixedUpdate()
    {
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 movimiento = direccion * velocidad;

        rb.linearVelocity = new Vector3(
            movimiento.x,
            rb.linearVelocity.y,
            movimiento.z
        );
    }

    void Saltar()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            rb.AddForce(Vector3.up * fuerzaSaltar, ForceMode.Impulse);
        }
    }
}