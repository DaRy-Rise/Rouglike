using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBtn : MonoBehaviour
{
    [HideInInspector]
    public bool PauseGame;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                ResumeToGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void LoadCampScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ResumeToGame()
    {
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseGame = true;
    }
}
