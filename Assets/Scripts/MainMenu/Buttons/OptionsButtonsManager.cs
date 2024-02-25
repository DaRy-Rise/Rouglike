using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonsManager : MonoBehaviour
{
    [SerializeField]
    private Button returnBtn, sound, language;
    [SerializeField]
    private Sprite returnImage, choosedReturnImage, soundImage, choosedSoundImage, languageImage, choosedLanguageImage;
    private int selectedIndex = 0;
    void Start()
    {
        SetButtonState();
    }

    void Update()
    {
        ChooseButton();
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (selectedIndex)
            {
                case 0:
                    CloseOptions();
                    break;
                case 1:
                    TurnSound();
                    break;
                case 2:
                    SetLanguage();
                    break;
                default:
                    break;
            }
        }
    }
    private void ChooseButton()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 0;
            SetButtonState();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
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
            returnBtn.image.sprite = choosedReturnImage;
            sound.image.sprite = soundImage;
            language.image.sprite = languageImage;
        }
        else if (selectedIndex == 1)
        {
            returnBtn.image.sprite = returnImage;
            sound.image.sprite = choosedSoundImage;
            language.image.sprite = languageImage;
        }
        else
        {
            returnBtn.image.sprite = returnImage;
            sound.image.sprite = soundImage;
            language.image.sprite = choosedLanguageImage;
        }
    }
    public void CloseOptions()
    {
        gameObject.SetActive(false);
    }
    public void TurnSound()
    {
        print("sound");
    }
    public void SetLanguage()
    {
        print("language");
    }
}
