using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingLevelScene : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadLevelScene();
        }
    }

    public static void LoadLevelScene()
    {
        GlobalStat globalStat = FindObjectOfType<GlobalStat>();
        globalStat.SetInfo();
        SceneManager.LoadScene(2);
    }
}