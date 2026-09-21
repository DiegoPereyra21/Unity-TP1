using System.Collections;
using UnityEngine;

//solo nivel 1: muestra instrucciones unos segundos y recien ahi aparecen los enemigos
public class Level1Intro : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject[] enemies;//dejarlos desactivados en el inspector
    [SerializeField] private float introDuration = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        yield return new WaitForSeconds(introDuration);

        instructionsPanel.SetActive(false);
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }
}