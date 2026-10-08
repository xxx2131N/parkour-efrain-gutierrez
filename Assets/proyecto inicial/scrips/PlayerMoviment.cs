using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private float velocidad = 5f;
    private float fuerzaSaltar = 10f;
    private float peso = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.mass = peso;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Transform camera = Camera.main.transform;

        Vector3 frente = camera.forward;
        Vector3 derecha = camera.right;

        frente.y = 0f;
        derecha.y = 0f;
        frente.Normalize();
        derecha.Normalize();

        Vector3 direccion = (frente * vertical + derecha * horizontal).normalized;

        Vector3 movimiento = direccion * velocidad;

        rb.linearVelocity = new Vector3(
            movimiento.x,
            rb.linearVelocity.y,
            movimiento.z
        );

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) <= 0.01f)
        {
            rb.AddForce(Vector3.up * fuerzaSaltar, ForceMode.Impulse);
        }
    }
}