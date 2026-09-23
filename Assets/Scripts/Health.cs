using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    //tuve que agregarlo porque aveces tiraba el log -20 de vida
    private bool isDead = false;
    //sonido de hit
    [SerializeField] private AudioClip hitSound;//mismo sonido para player y enemigos
    [SerializeField] private AudioClip enemyDeathSound;//solo para cuando muere un enemigo
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
        PlaySound(hitSound);//asi el sonido no se corta aunque el objeto se destruya despues
        if (currentHealth <= 0)
        {
            isDead = true;
            //elgamemanager ahora es singleton, ya no hace falta buscarlo por tag

            if (CompareTag("Player"))
            {
                GameManager.Instance.PlayerDie();
            }
            else
            {
                PlaySound(enemyDeathSound);
                GameManager.Instance.EnemyDie();
                Destroy(gameObject);
            }
        }
    }

    //necesario, no se escuchaba con el 3d, con esto aunque el enemigo muera dejara el sonido y se escuchara bien
    void PlaySound(AudioClip clip)
    {
        GameObject temp = new GameObject("TempAudio");
        AudioSource src = temp.AddComponent<AudioSource>();
        src.clip = clip;
        src.Play();
        Destroy(temp, clip.length);
    }
}