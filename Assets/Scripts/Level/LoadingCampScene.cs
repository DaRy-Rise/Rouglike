using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingCampScene : MonoBehaviour
{
    public static void LoadCampScene()
    {
        GlobalStat globalStat = FindObjectOfType<GlobalStat>();
        globalStat.SetInfo();
        SceneManager.LoadScene(0);
    }
}
