using UnityEngine;
using UnityEngine.UI;

public class DisplayButtonsManager : MonoBehaviour
{
    private InputReader inputReader;
    [SerializeField]
    private TMPro.TMP_Dropdown resDropdown, screenDropdown;
    [SerializeField]
    private GameObject optionsButtonManager,selector;
    DisplaySelectorState currentState;
    private bool isResOpen, isScreenOpen;
    Vector2 resPoint = new(4.1f, -0.32f);
    Vector3 screenPoint = new(4.1f, -1.41f);
    private void OnDisable()
    {
        inputReader.VerticalUpChoosingEvent -= MoveUp;
        inputReader.VerticalDownChoosingEvent -= MoveDown;
        inputReader.EnterEvent -= ShowDpDown;
        inputReader.ExitEvent -= CloseOptions;
    }
    private void Awake()
    {
        inputReader = FindAnyObjectByType<InputReader>();
    }
    private void OnEnable()
    {
        optionsButtonManager.SetActive(false);
        inputReader.VerticalUpChoosingEvent += MoveUp;
        inputReader.VerticalDownChoosingEvent += MoveDown;
        inputReader.EnterEvent += ShowDpDown;
        inputReader.ExitEvent += CloseOptions;
        currentState = DisplaySelectorState.Resolution;
        isResOpen = false;
        isScreenOpen = false;
        ChangePosition(resPoint);
    }
    void Start()
    {
        inputReader = FindAnyObjectByType<InputReader>();
    }
    private void MoveUp()
    {
        if (isResOpen)
        {

        }
        else if (isScreenOpen)
        {

        }
        else
        {
            switch (currentState)
            {
                case DisplaySelectorState.Resolution:
                    break;
                case DisplaySelectorState.Screen:
                    ChangePosition(resPoint);
                    currentState = DisplaySelectorState.Resolution;
                    break;
                default:
                    break;
            }
        }
    }
    private void MoveDown()
    {
        if (isResOpen)
        {

        }
        else if(isScreenOpen)
        {

        }
        else
        {
            switch (currentState)
            {
                case DisplaySelectorState.Resolution:
                    ChangePosition(screenPoint);
                    currentState = DisplaySelectorState.Screen;
                    break;
                case DisplaySelectorState.Screen:
                    break;
                default:
                    break;
            }
        }

    }
    public void ChangePosition(Vector2 position)
    {
        selector.gameObject.transform.position = position;
    }
    public void CloseOptions()
    {
        if(isResOpen)
        {
            resDropdown.Hide();
            isResOpen = false;
        }
        else if(isScreenOpen)
        {
            screenDropdown.Hide();
            isScreenOpen = false;
        }
        else
        {
            resDropdown.Hide();
            screenDropdown.Hide();
            optionsButtonManager.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void ShowDpDown()
    {
        if(!isResOpen&&!isScreenOpen)
        {
            switch (currentState)
            {
                case DisplaySelectorState.Resolution:
                    resDropdown.Show();
                    ChooseResolutionDropValue();
                    isResOpen = true;
                    break;
                case DisplaySelectorState.Screen:
                    screenDropdown.Show();
                    isScreenOpen = true;
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (isResOpen)
            {
                ChooseResolutionDropValue();
                isResOpen = false;
            }
            else
            {
                ChooseScreenDropValue();
                isScreenOpen = false;
            }
        }
    }
    public void ChooseResolutionDropValue()
    {
        switch (resDropdown.value)
        {
            case 0: Screen.SetResolution(320, 240, true);
                break;
            case 1:
                Screen.SetResolution(640, 480, true); 
                break;
            case 2:
                Screen.SetResolution(800, 600, true);
                break;
            case 3:
                Screen.SetResolution(1280, 720, true);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 5:
                Screen.SetResolution(2560, 1440, true);
                break;
            case 6:
                Screen.SetResolution(3840, 2160, true);
                break;
            default:
                break;
        }
    }
    public void ChooseScreenDropValue()
    {
        switch (resDropdown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            default:
                break;
        }
    }
}
enum DisplaySelectorState
{
    Resolution,
    Screen
}