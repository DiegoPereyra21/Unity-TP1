using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel 1");
    }
    public void Nivel2()
    {
        SceneManager.LoadScene("Nivel 2");
    }
    public void Nivel3()
    {
        SceneManager.LoadScene("Nivel 3");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnToMenu()//para q la escena win y lose no necesiten otro script
    {
        SceneManager.LoadScene("Menu");
    }
    //agregados para el segundo tp
    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
    public void NextLevel()
    {
        GameManager.Instance.GoToNextLevel();
    }
}
