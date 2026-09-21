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

        Aim();
    }
    private void FixedUpdate()
    {
        if (dir != Vector3.zero)//buena practica q estos calculos sean en fixedupdate
        {
            transform.forward = dir;
        }
    }
    //para que apunte directamente al puntero, se sentia muy tosco el disparo antes
    void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        if (ground.Raycast(ray, out float dist))
        {
            Vector3 point = ray.GetPoint(dist);
            Vector3 lookDir = point - transform.position;
            lookDir.y = 0f;

            if (lookDir != Vector3.zero)
                transform.forward = lookDir;
        }
    }
}