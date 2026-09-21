using UnityEngine;

//va en un objeto vacio de cada escena de nivel, para decirle al GameManager cuantos enemigos hay y si es el ultimo nivel
public class LevelConfig : MonoBehaviour
{
    [SerializeField] private int enemiesToKill = 3;
    [SerializeField] private bool isLastLevel = false;

    void Start()
    {
        //por si abro el nivel directo sin pasar por el Menu, para poder testear
        if (GameManager.Instance == null)
        {
            GameObject gm = new GameObject("GameManager");
            gm.AddComponent<GameManager>();
        }
        GameManager.Instance.ConfigureLevel(enemiesToKill, isLastLevel);
    }
}