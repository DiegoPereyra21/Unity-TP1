using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int enemiesToKill = 3;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void EnemyDie()
    {
        enemiesToKill--;
        Debug.Log("ENEMIGOS RESTANTES: " + enemiesToKill);//Debug mas importante creo yo
        if (enemiesToKill<=0)
        {
            Debug.Log("VICTORIA EN " + timer.ToString());
            NextLvl();
        }

    }

    public void PlayerDie()
    {
        Debug.Log("TIEMPO QUE SOBREVIVISTE: "+ timer.ToString());
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
