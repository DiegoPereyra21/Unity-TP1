using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    //tuve que agregarlo porque aveces tiraba el log -20 de vida
    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        //la consigna lo pide
        Debug.Log("VIDA INICIAL: " + currentHealth);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;//para q deje de recibir daño si ya murio

        currentHealth -= amount;
        Debug.Log("VIDA ACTUAL: " + currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            //el GameManager ahora es singleton persistente, ya no hace falta buscarlo por tag

            if (CompareTag("Player"))
            {
                GameManager.Instance.PlayerDie();
            }
            else
            {
                GameManager.Instance.EnemyDie();
                Destroy(gameObject);
            }
        }
    }
}