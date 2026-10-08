using UnityEngine;

public class Empujable : MonoBehaviour
{
    [SerializeField] private float desintegracionFuerza = 5f; // Qué tan rápido se frena el empuje
    private Vector3 fuerzaActual = Vector3.zero;
    private CharacterController characterController;
    private Rigidbody rb;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Si el personaje usa CharacterController, movemos progresivamente con la fuerza residual
        if (characterController != null && fuerzaActual.magnitude > 0.1f)
        {
            characterController.Move(fuerzaActual * Time.deltaTime);
            // Reduce la fuerza con el tiempo para lograr un frenado suave
            fuerzaActual = Vector3.Lerp(fuerzaActual, Vector3.zero, desintegracionFuerza * Time.deltaTime);
        }
    }

    // Método que llamará cualquier obstáculo para empujar al personaje
    public void Empujar(Vector3 direccion, float fuerza)
    {
        Vector3 direccionFuerza = direccion.normalized * fuerza;

        if (characterController != null)
        {
            // Acumula la fuerza para el CharacterController
            fuerzaActual += direccionFuerza;
        }
        else if (rb != null)
        {
            // Si el personaje usa Rigidbody
            rb.AddForce(direccionFuerza, ForceMode.Impulse);
        }
    }
}