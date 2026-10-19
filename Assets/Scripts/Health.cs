using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    //tuve que agregarlo porque aveces tiraba el log -20 de vida
    private bool isDead = false;
    //sonido de hit
    [SerializeField] private AudioClip hitSound;//mismo sonido para player y enemigos
    //antes era enemyDeathSound, el FormerlySerializedAs es para no perder el clip ya asignado en los prefabs xq no voy a asignar siempre
    [FormerlySerializedAs("enemyDeathSound")]
    [SerializeField] private AudioClip deathSound;//ahora lo usa tambien el player
    void Start()
    {
        currentHealth = maxHealth;
        //la consigna lo pide, name toma el nombre tanto del palyer como de los enemigos
        Debug.Log(name + " VIDA INICIAL: " + currentHealth);
    }

    //lo usa el EnemyFear paara huir si le queda poca vida, luego vere si agrego algo parecido con enemy seeker para que se mueva mas rapido si tiene poca vida
    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;//para q deje de recibir daño si ya murio

        currentHealth -= amount;
        //la consigna del segundo pacial pide el daño q recibe y la vida despues del golpe, facil
        Debug.Log(name + " RECIBIO " + amount + " DE DANIO"); //recibio y no recibi, pq funciona para ambos y quite ñ
        Debug.Log(name + " VIDA ACTUAL: " + currentHealth);
        PlaySound(hitSound);//asi el sonido no se corta aunque el objeto se destruya despues

        if (currentHealth <= 0)
        {
            isDead = true;
            PlaySound(deathSound);

            if (CompareTag("Player"))
            {
                Debug.Log("GAME OVER - MURIO EL JUGADOR"); //para consigna
                GameManager.Instance.PlayerDie();
            }
            else
            {
                Debug.Log("ENEMIGO ELIMINADO: " + name);//si no es player ve el nombre del q murio
                GameManager.Instance.EnemyDie();
            }
            //ahora el player tambien se elimina de la escena, los enemigos ya chequean si es null
            Destroy(gameObject);
        }
    }

    //necesario, no se escuchaba con el 3d, con esto aunque el enemigo muera dejara el sonido y se escuchara bien
    void PlaySound(AudioClip clip)
    {
        if (clip == null) return;//por si alguno quedo sin asignar en el inspector, deberia poner algun debug
        GameObject temp = new GameObject("TempAudio");
        AudioSource src = temp.AddComponent<AudioSource>();
        src.clip = clip;
        src.Play();
        Destroy(temp, clip.length);
    }
}