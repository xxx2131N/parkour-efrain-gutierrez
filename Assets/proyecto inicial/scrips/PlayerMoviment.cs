using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    private Vector3 direccion= Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float saltar = Input.GetAxisRaw("Jump");

        direccion = new Vector3(horizontal, saltar, vertical);
        Vector3 movimiento = direccion * velocidad * Time.deltaTime;
        transform.Translate(movimiento, Space.World);
    }
}
