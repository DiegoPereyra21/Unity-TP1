using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile1;
    //aparte de daño y tamaño del projectile 2, debo hacerle otra particularidad
    [SerializeField] private GameObject projectile2;
    [SerializeField] private float cdProjectile1 = 0.25f;
    [SerializeField] private float cdProjectile2 = 1.5f;
    private float nextShootProjectile1 = 0f;
    private float nextShootProjectile2 = 0f;
    private Rigidbody rb;
    private Vector3 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //input viejo, a futuro cambiar al actual 
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, 0f, v).normalized;

        //me complique con el temporizador, use el mismo q en enemy
        if (Input.GetMouseButtonDown(0) && Time.time >= nextShootProjectile1)
        {
            Instantiate(projectile1, firePoint.position, firePoint.rotation);
            nextShootProjectile1 = Time.time + cdProjectile1;
        }
            
        if (Input.GetMouseButtonDown(1)&& Time.time >= nextShootProjectile2)
        {
            Instantiate(projectile2, firePoint.position, firePoint.rotation);
            nextShootProjectile2 = Time.time + cdProjectile2;
        }

        rb.linearVelocity = new Vector3(dir.x * speed, rb.linearVelocity.y, dir.z * speed);

        if (dir != Vector3.zero)
            transform.forward = dir;
    }
}