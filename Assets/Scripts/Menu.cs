using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;//corto para botones normales
    [SerializeField] private AudioClip playSound;//largo para empzar partidas
    //tuve q cambiar todo, xq no se reproducia el sonido si cambiaba de escena
    public void Play()
    {
        StartCoroutine(LoadWithSound(playSound, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)));
    }
    public void Nivel1()
    {
        StartCoroutine(LoadWithSound(clickSound, () => SceneManager.LoadScene("Nivel 1")));
    }
    public void Nivel2()
    {
        StartCoroutine(LoadWithSound(clickSound, () => SceneManager.LoadScene("Nivel 2")));
    }
    public void Nivel3()
    {
        StartCoroutine(LoadWithSound(clickSound, () => SceneManager.LoadScene("Nivel 3")));
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnToMenu()//para q la escena win y lose no necesiten otro script
    {
        StartCoroutine(LoadWithSound(clickSound, () => SceneManager.LoadScene("Menu")));
    }
    //agregados para el segundo tp
    public void RestartLevel()
    {
        StartCoroutine(LoadWithSound(clickSound, () => GameManager.Instance.RestartLevel()));
    }
    public void NextLevel()
    {
        StartCoroutine(LoadWithSound(clickSound, () => GameManager.Instance.GoToNextLevel()));
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

    //generalize lo q tenia para play nada mas, ahora cualquier boton que cambie de escena pasa por aca, asi no se corta el sonido
    IEnumerator LoadWithSound(AudioClip clip, System.Action loadAction)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        loadAction();
    }
}