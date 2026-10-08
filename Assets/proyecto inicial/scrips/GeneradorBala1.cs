using UnityEngine;

public class GeneradorBala1 : MonoBehaviour
{
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private float tiempoInicial = 2f;
    [SerializeField] private float intervalo = 2f;
    [SerializeField] private float velocidadBala = 10f;

    void Start()
    {
        InvokeRepeating(nameof(CrearBala), tiempoInicial, intervalo);
    }

    private void CrearBala()
    {
        // Validación para evitar errores si no asignaste el prefab
        if (balaPrefab == null)
        {
            Debug.LogWarning("¡No has asignado el 'balaPrefab' en el Inspector!");
            return;
        }

        // Instanciar la bala en la posición y rotación del generador
        GameObject nuevaBala = Instantiate(balaPrefab, transform.position, transform.rotation);
    
        // Obtener el Rigidbody de la bala instanciada
        Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Usa 'velocity' si tu versión de Unity no reconoce 'linearVelocity'
            rb.linearVelocity = transform.forward * velocidadBala;
        }

        // Destruir la bala después de 5 segundos para ahorrar memoria
        Destroy(nuevaBala, 5f);
    }
}