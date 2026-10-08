using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform objetivo; // El objetivo que la cámara seguirá
    [SerializeField] private float distancia = 5f;
    [SerializeField] private float altura = 2f;
    [SerializeField] private float sencibilidad = 2f;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro
        Cursor.visible = false; // Oculta el cursor
    }

    void Update()
    {
        // Multiplicamos por sencibilidad para ajustar la velocidad del mouse
        rotacionX += Input.GetAxis("Mouse X") * sencibilidad;
        rotacionY -= Input.GetAxis("Mouse Y") * sencibilidad;

        // Limita la mirada vertical para evitar giros raros o que se dé vuelta la cámara
        rotacionY = Mathf.Clamp(rotacionY, -30f, 60f);
    }

    void LateUpdate()
    {
        if (objetivo == null) return;

        // IMPORTANTE: rotacionY va primero (eje X en Euler) y rotacionX va segundo (eje Y en Euler)
        Quaternion rotacionDeseada = Quaternion.Euler(rotacionY, rotacionX, 0);

        Vector3 posicionDeseada = objetivo.position - (rotacionDeseada * Vector3.forward * distancia) + (Vector3.up * altura);

        transform.position = posicionDeseada;
        transform.LookAt(objetivo.position + Vector3.up * 1f);
    }
}