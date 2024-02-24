using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private Button play, options, exit;
    [SerializeField]
    private Sprite playImage, choosedPlayImage, optionsImage, choosedOptionsImage, exitImage, choosedExitImage;
    [SerializeField]
    private GameObject OptionsMenu;
    private int selectedIndex = 0;
    private void Start()
    {
        SetButtonState();
    }
    void Update()
    {
        if (!OptionsMenu.activeSelf) 
        {
            ChooseButton();
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (selectedIndex)
                {
                    case 0:
                        LoadSceneCamp();
                        break;
                    case 1:
                        OpenOptions();
                        break;
                    case 2:
                        ExitFromGame();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    private void ChooseButton()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 0;
            SetButtonState();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            selectedIndex++;
            if (selectedIndex > 2)
                selectedIndex = 2;
            SetButtonState();
        }
    }
    private void SetButtonState()
    {
        if (selectedIndex == 0)
        {
            play.image.sprite = choosedPlayImage;
            options.image.sprite = optionsImage;
            exit.image.sprite = exitImage;
        }
        else if (selectedIndex == 1)
        {
            play.image.sprite = playImage;
            options.image.sprite = choosedOptionsImage;
            exit.image.sprite = exitImage;
        }
        else
        {
            play.image.sprite = playImage;
            options.image.sprite = optionsImage;
            exit.image.sprite = choosedExitImage;
        }
    }
    public void LoadSceneCamp()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenOptions()
    {
        OptionsMenu.SetActive(true);
    }
    public void ExitFromGame()
    {
        print("EXIT");
    }
}
