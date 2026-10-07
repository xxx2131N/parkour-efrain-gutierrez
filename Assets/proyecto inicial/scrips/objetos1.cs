using UnityEngine;

public class objetos1 : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,velocidad * Time.deltaTime);
    }
}
