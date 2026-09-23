using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyProjectile;
    [SerializeField] private float startDelay = 1.5f;//para que no disparen apenas aparecen
    public float fireRate = 2f;
    private Transform transformPlayer;
    [SerializeField] private float projectileDamage = 12f;
    [SerializeField] private Transform player;
    private float nextFire;

    //para el sonido de la bola de fuego
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] fireballSounds;//f1,f2,f3, uno al azar por disparo para que no suene repetitivo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //seguridad x si nos olvidamos algo
        if (player == null || firePoint == null || enemyProjectile == null)
        {
            Debug.LogWarning(name + " faltan referencias");
            enabled = false;
            return;
        }
        transformPlayer = player.transform;
        nextFire = Time.time + startDelay;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transformPlayer);

        if (Time.time >= nextFire)
        {
            GameObject Projectile = Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
            //para la consigna de que tengan mas daño segun el nivel, hasta ahora solo cambiaba el firerate pero no esta en la consigna
            Projectile.GetComponent<ProjectileEnemy>().SetDamage(projectileDamage);
            audioSource.PlayOneShot(fireballSounds[Random.Range(0, fireballSounds.Length)]);//sonido de la bola de fuego
            nextFire = Time.time + fireRate;
        }
    }

}