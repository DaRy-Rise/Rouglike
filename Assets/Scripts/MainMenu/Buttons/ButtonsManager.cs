using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionsMenu, selector;
    private InputReader inputReader;
    MainMenuSelectorState currentState;
    Vector2 startPoint = new(4.1f, 0.9f);
    Vector3 optionsPoint = new(4.1f, -0.48f);
    Vector3 exitPoint = new(4.1f, -1.9f);
    private void OnDisable()
    {
        inputReader.VerticalUpChoosingEvent -= MoveUp;
        inputReader.VerticalDownChoosingEvent -= MoveDown;
        inputReader.EnterEvent -= ChooseMenuButtons;
    }
    private void OnEnable()
    {
        ChangeSelectorPosition(startPoint);
        currentState = MainMenuSelectorState.Start;
        inputReader.VerticalUpChoosingEvent += MoveUp;
        inputReader.VerticalDownChoosingEvent += MoveDown;
        inputReader.EnterEvent += ChooseMenuButtons;
    }
    private void Awake()
    {
        inputReader = FindAnyObjectByType<InputReader>();
    }
    void Start()
    {
        inputReader = FindAnyObjectByType<InputReader>();
    }
    private void MoveUp()
    {

        switch (currentState)
        {
            case MainMenuSelectorState.Start:
                break;
            case MainMenuSelectorState.Options:
                ChangeSelectorPosition(startPoint);
                currentState = MainMenuSelectorState.Start;
                break;
            case MainMenuSelectorState.Exit:
                ChangeSelectorPosition(optionsPoint);
                currentState = MainMenuSelectorState.Options;
                break;
            default:
                break;
        }
    }
    private void MoveDown()
    {

        switch (currentState)
        {
            case MainMenuSelectorState.Start:
                ChangeSelectorPosition(optionsPoint);
                currentState = MainMenuSelectorState.Options;
                break;
            case MainMenuSelectorState.Options:
                ChangeSelectorPosition(exitPoint);
                currentState = MainMenuSelectorState.Exit;
                break;
            case MainMenuSelectorState.Exit:
                break;
            default:
                break;
        }
    }
    public void ChangeSelectorPosition(Vector2 position)
    {
        selector.gameObject.transform.position = position;
    }
    public void ChooseMenuButtons()
    {
        switch (currentState)
        {
            case MainMenuSelectorState.Start:
                LoadSceneCamp();
                break;
            case MainMenuSelectorState.Options:
                OpenOptions();
                break;
            case MainMenuSelectorState.Exit:
                ExitFromGame();
                break;
            default:
                break;
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
enum MainMenuSelectorState
{
    Start,
    Options,
    Exit
}
