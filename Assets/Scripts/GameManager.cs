using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int enemiesToKill = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDie()
    {
        enemiesToKill--;
        if (enemiesToKill<=0)
        {
            NextLvl();
        }
        Debug.Log("ENEMIGOS RESTANTES: " + enemiesToKill);//Debug mas importante creo yo
    }

    public void PlayerDie()
    {
        lose();
    }

    /*
    //vere si lo utilizo
    void win()
    {
        SceneManager.LoadScene("Win");
    }
    */

    void lose()
    {
        SceneManager.LoadScene("Lose");
    }
    void NextLvl()
    {
        //la idea es q win se llegue sumando 1 en el ultimo nivel, no llamandolo creeria. y lose solamente se llegue muriendo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
