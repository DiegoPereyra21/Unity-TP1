using UnityEngine;

public class EnemyFear : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyProjectile;
    public float fireRate = 2f;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float projectileDamage = 12f;
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
            GameObject Projectile = Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
            //para la consigna de que tengan mas daño segun el nivel, hasta ahora solo cambiaba el firerate pero no esta en la consigna
            Projectile.GetComponent<ProjectileEnemy>().SetDamage(projectileDamage);
            nextFire = Time.time + fireRate;
        }
    }
}
