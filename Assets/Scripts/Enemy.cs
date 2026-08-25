using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyProjectile;
    public float fireRate = 2f;
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

        if (Time.time >= nextFire)
        {
            Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }

}