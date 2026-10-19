using TMPro;
using UnityEngine;
using UnityEngine.UI;

//muestra la vida del player, los enemigos que faltan y el tiempo, se actualiza cada frame
public class HUD : MonoBehaviour
{
    [SerializeField] private Image healthFill;//imagen tipo Filled, se achica con la vida
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text enemiesText;
    [SerializeField] private TMP_Text timerText;
    private Health playerHealth;

    void Start()
    {
        //lo busco por tag asi el prefab del HUD sirve en todos los niveles sin asignar nada a mano
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        //si el player ya se destruyo, muestra 0
        float percent = playerHealth != null ? playerHealth.GetHealthPercent() : 0f;
        float current = playerHealth != null ? playerHealth.GetCurrentHealth() : 0f;

        healthFill.fillAmount = Mathf.Clamp01(percent);
        healthText.text = "Vida: " + Mathf.Max(0, current);
        enemiesText.text = "Enemigos: " + GameManager.Instance.GetEnemiesLeft();
        timerText.text = "Tiempo: " + GameManager.Instance.GetTimer().ToString("F1");
    }
}