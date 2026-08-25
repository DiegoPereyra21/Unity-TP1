using UnityEngine;

public class Health : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("VIDA ACTUAL: " + currentHealth);

        if (currentHealth <= 0 )
        {
            if (CompareTag("Player"))
            {
                gameManager.PlayerDie();
                Debug.Log("You Die!");

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