using UnityEngine;

public class Health : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    //tuve que agregarlo porque aveces tiraba el log -20 de vida
    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //la consigna lo pide
        Debug.Log("VIDA INICIAL: " + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        if (isDead) return;//para q deje de recibir daño si ya murio, iba a hacer una especie de ragdoll pero mejor no

        currentHealth -= amount;
        Debug.Log("VIDA ACTUAL: " + currentHealth);

        if (currentHealth <= 0 )
        {
            isDead = true;
            if (CompareTag("Player"))
            {
                gameManager.PlayerDie();

            }
            else
            {
                //Debug.Log("Enemy Die!"); lo quito porque el gamemanager ya muestra el enemigos restantes
                gameManager.EnemyDie();
                Destroy(gameObject);
            }
        }
    }
}