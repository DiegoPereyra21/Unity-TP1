using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject tutorialPanel;
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
    //para la consiga de agregar tutorial en el menu de inicio
    public void ShowTutorial()
    {
        mainMenuPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }
    public void HideTutorial()//boton volver del tutorial, deja el menu como estaba
    {
        tutorialPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
