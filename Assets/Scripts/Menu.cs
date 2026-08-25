using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnToMenu()//para q la escena win y lose no necesiten otro script
    {
        SceneManager.LoadScene("Menu");
    }
}
