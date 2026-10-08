using UnityEngine;

public class ImpactoBala : MonoBehaviour
{
    [SerializeField] private float fuerzaEmpuje= 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision colision)
    {
        Empujable empujable = colision.gameObject.GetComponent<Empujable>();
        if (empujable != null)
        {
            Vector3 direccionEmpuje = colision.transform.position - transform.position;
            empujable.Empujar(direccionEmpuje, fuerzaEmpuje);
        }
        Destroy(gameObject);
    }
}
