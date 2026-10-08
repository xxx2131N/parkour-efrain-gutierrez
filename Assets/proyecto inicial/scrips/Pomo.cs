using UnityEngine;

public class Pomo : MonoBehaviour
{
    [SerializeField] private Salida objetoSalida; // Arrastra el objeto Salida en el Inspector
    private bool jugadorCerca = false;

    void Update()
    {
        // Si el jugador está cerca y presiona la tecla E
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            // Le avisa a la salida que desaparezca
            if (objetoSalida != null)
            {
                objetoSalida.DesaparecerSalida();
            }

            // Desaparece el pomo
            gameObject.SetActive(false);
        }
    }

    // Detecta cuando el personaje entra en la zona del pomo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    // Detecta cuando el personaje sale de la zona del pomo
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}