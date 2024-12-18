using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBtn : MonoBehaviour
{
    [HideInInspector]
    public bool PauseGame;
    [SerializeField]
    private GameObject pauseMenu;

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
        SceneManager.LoadScene(1);
    }

    public void ResumeToGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        PauseGame = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        PauseGame = true;
    }
}
