using UnityEngine;

public class objetos1 : MonoBehaviour
{
    [SerializeField] private float velocidad = 50f;
    private Rigidbody rb;

    void Start()
    {
        // Intenta obtener el Rigidbody
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Falta agregar el componente Rigidbody a " + gameObject.name + ". Agrégalo y marca 'Is Kinematic'.");
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            // Mueve el objeto usando físicas (empuja al personaje)
            Quaternion rotacionFrame = Quaternion.Euler(0, 0, velocidad * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * rotacionFrame);
        }
    }

    void Update()
    {
        // Si no tiene Rigidbody, gira de la forma básica
        if (rb == null)
        {
            transform.Rotate(0, 0, velocidad * Time.deltaTime);
        }
    }
}