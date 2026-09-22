using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//singleton, para que sobreviva entre escenas y sepa que nivel reiniciar o seguir

    private int enemiesToKill;
    private bool isLastLevel;
    private int currentLevelIndex;
    private float timer = 0f;
    private bool levelEnded = false;//para que no se cargue la escena dos veces si pasa algo el mismo frame(muere 2 enemigos al mismo tiemepo o algo raro)

    void Awake()
    {
        //si ya hay un GameManager de otra escena, este nuevo sobra
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    //lo llama el LevelConfig de cada nivel al arrancar
    public void ConfigureLevel(int enemyCount, bool lastLevel)
    {
        enemiesToKill = enemyCount;
        isLastLevel = lastLevel;
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        timer = 0f;
        levelEnded = false;
    }

    public void EnemyDie()
    {
        if (levelEnded) return;
        enemiesToKill--;
        Debug.Log("ENEMIGOS RESTANTES: " + enemiesToKill);//Debug mas importante creo yo
        if (enemiesToKill <= 0)
        {
            levelEnded = true;
            Debug.Log("VICTORIA EN " + timer.ToString());
            win();
        }
    }

    public void PlayerDie()
    {
        if (levelEnded) return;
        levelEnded = true;
        Debug.Log("TIEMPO QUE SOBREVIVISTE: " + timer.ToString());
        lose();
    }

    void win()
    {
        //si es el ultimo nivel va a ganar el juego, sino a ganar nivel
        SceneManager.LoadScene(isLastLevel ? "WinGame" : "Win");
    }

    void lose()
    {
        SceneManager.LoadScene("Lose");
    }

    //boton reintentar de la pantalla de perder
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }

    //boton siguiente nivel de la pantalla de ganar nivel
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(currentLevelIndex + 1);
    }
}