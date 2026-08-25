using UnityEngine;

public class EnemyFear : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyProjectile;
    public float fireRate = 2f;
    [SerializeField] private float speed = 1.5f;
    private Transform transformPlayer;

    [SerializeField] private Transform player;
    private float nextFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformPlayer = player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transformPlayer);
        //logica para que se aleje lentamente
        Vector3 fleeTarget = transform.position + (transform.position - player.position);
        transform.position = Vector3.MoveTowards(transform.position, fleeTarget, speed * Time.deltaTime);

        if (Time.time >= nextFire)
        {
            Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
