using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    //tuve que agregarlo porque aveces tiraba el log -20 de vida
    private bool isDead = false;
    //sonido de hit
    [SerializeField] private AudioClip hitSound;//mismo sonido para player y enemigos
    //antes era enemyDeathSound, el FormerlySerializedAs es para no perder el clip ya asignado en los prefabs
    [FormerlySerializedAs("enemyDeathSound")]
    [SerializeField] private AudioClip deathSound;//ahora lo usa tambien el player
    [SerializeField] private float deathDelay = 1.5f;//lo que tarda en desaparecer para que se vea la animde muerte
    private Animator anim;


    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();//el animator esta en el hijo no root
        //la consigna lo pide
        Debug.Log(name + " VIDA INICIAL: " + currentHealth);
    }

    //lo usa el EnemyFear para decidir si huir con poca vida
    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;//para q deje de recibir daño si ya murio

        currentHealth -= amount;
        //la consigna pide el daño recibido y la vida despues del golpe
        Debug.Log(name + " RECIBIO " + amount + " DE DAÑO");
        Debug.Log(name + " VIDA ACTUAL: " + currentHealth);
        PlaySound(hitSound);//asi el sonido no se corta aunque el objeto se destruya despues

        if (currentHealth <= 0)
        {
            isDead = true;
            PlaySound(deathSound);

            if (CompareTag("Player"))
            {
                Debug.Log("GAME OVER - MURIO EL JUGADOR");
                GameManager.Instance.PlayerDie();
            }
            else
            {
                Debug.Log("ENEMIGO ELIMINADO: " + name);
                GameManager.Instance.EnemyDie();
            }

            if (anim != null) anim.SetTrigger("die");
            DisableOnDeath();
            //ya no se destruye al toque, espera a que termine la animacion
            Destroy(gameObject, deathDelay);
        }
    }

    //apaga todo lo que lo mueve o dispara, asi la animacion de muerte se ve quieta
    void DisableOnDeath()
    {
        foreach (MonoBehaviour script in GetComponents<MonoBehaviour>())
        {
            if (script != this) script.enabled = false;
        }

        NavMeshAgent agent = GetComponent<NavMeshAgent>();//solo el seeker lo tiene
        if (agent != null) agent.enabled = false;

        GetComponent<Collider>().enabled = false;//para que las balas lo atraviesen mientras muere

        Rigidbody rb = GetComponent<Rigidbody>();
        if (!rb.isKinematic) rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;//sin collider se caeria por el piso
    }

    //necesario, no se escuchaba con el 3d, con esto aunque el enemigo muera dejara el sonido y se escuchara bien
    void PlaySound(AudioClip clip)
    {
        if (clip == null) return;//por si alguno quedo sin asignar en el inspector, que no tire error
        GameObject temp = new GameObject("TempAudio");
        AudioSource src = temp.AddComponent<AudioSource>();
        src.clip = clip;
        src.Play();
        Destroy(temp, clip.length);
    }
}