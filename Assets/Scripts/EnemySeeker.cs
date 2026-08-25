using UnityEngine;

public class EnemySeeker : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyProjectile;
    public float fireRate = 2f;
    private Transform transformPlayer;
    //lento porque la idea no es que nos golpee melee
    [SerializeField] private float speed = 1.5f;


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
        //logica para q se acerque
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (Time.time >= nextFire)
        {
            Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
