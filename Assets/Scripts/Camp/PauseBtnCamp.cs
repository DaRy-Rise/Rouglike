using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBtnCamp : MonoBehaviour
{
    [HideInInspector]
    public bool PauseGame;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    DialogSystem dialogSystem;
    [SerializeField]
    TreeOfAbilityManager treeOfAbilityManager;
    [SerializeField]
    private Button back, menu;
    [SerializeField]
    private Sprite backImage, choosedBackImage, menuImage, choosedMenuImage;

    private int selectedIndex = 0;
    public void Update()
    {
        ChooseButton();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (DialogSystem.isBoxOpen)
            {
                dialogSystem.StopDialog();
            }
            else if (TreeOfAbilityManager.isTreeOpen)
            {
                treeOfAbilityManager.CloseTree();
            }
            else
            {
                TogglePause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (selectedIndex)
            {
                case 0:
                    ResumeToGame();
                    break;
                case 1:
                    LoadMainMenuScene();
                    break;
                default:
                    break;
            }
        }
    }
    private void ChooseButton()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 0;
            SetButtonState();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            selectedIndex++;
            if (selectedIndex > 1)
                selectedIndex = 1;
            SetButtonState();
        }
    }

    private void SetButtonState()
    {
        if (selectedIndex == 0)
        {
            back.image.sprite = choosedBackImage;
            menu.image.sprite = menuImage;
        }
        else
        {
            back.image.sprite = backImage;
            menu.image.sprite = choosedMenuImage;
        }
    }
    public void LoadMainMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void TogglePause()
    {
        if(PauseGame)
        {
            ResumeToGame();
        } else
        {
            Pause();
        }
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
        SetButtonState();
        PauseGame = true;
    }
}
