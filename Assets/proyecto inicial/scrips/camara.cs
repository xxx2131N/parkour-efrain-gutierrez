using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private float sensibilidad = 100f;

    private float rotacionX = 0f;

    public Transform Player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        Player.Rotate(Vector3.up * mouseX);
    }
}
