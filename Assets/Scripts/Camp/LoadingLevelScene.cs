using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingLevelScene : MonoBehaviour
{
    public static void LoadLevelScene()
    {
        GlobalStat globalStat = FindObjectOfType<GlobalStat>();
        globalStat.SetInfo();
        SceneManager.LoadScene(1);
    }
}
