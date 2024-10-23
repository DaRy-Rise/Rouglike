using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonsManager : MonoBehaviour
{
    private InputReader inputReader;
    [SerializeField]
    GameObject selector,menuButtonManager, displayMenu;
    OptionsSelectorState currentState;
    Vector2 soundPoint = new(4.1f, 0.22f);
    Vector3 languagePoint = new(4.1f, -0.88f);
    Vector3 displayPoint = new(4.1f, -1.97f);
    private void OnDisable()
    {
        inputReader.VerticalUpChoosingEvent -= MoveUp;
        inputReader.VerticalDownChoosingEvent -= MoveDown;
        inputReader.EnterEvent -= ChooseOptions;
        inputReader.ExitEvent -= CloseOptions;
    }
    private void Awake()
    {
        inputReader = FindAnyObjectByType<InputReader>();
    }
    private void OnEnable()
    {
        menuButtonManager.SetActive(false);
        inputReader.VerticalUpChoosingEvent += MoveUp;
        inputReader.VerticalDownChoosingEvent += MoveDown;
        inputReader.EnterEvent += ChooseOptions;
        inputReader.ExitEvent += CloseOptions;
        ChangePosition(soundPoint);
    }
    void Start()
    {
        currentState = OptionsSelectorState.Sound;
        inputReader = FindAnyObjectByType<InputReader>();
    }
    private void MoveUp()
    {
        switch (currentState)
        {
            case OptionsSelectorState.Sound:
                break;
            case OptionsSelectorState.Language:
                ChangePosition(soundPoint);
                currentState = OptionsSelectorState.Sound;
                break;
            case OptionsSelectorState.Display:
                ChangePosition(languagePoint);
                currentState = OptionsSelectorState.Language;
                break;
            default:
                break;
        }
    }
    private void MoveDown()
    {

        switch (currentState)
        {
            case OptionsSelectorState.Sound:
                ChangePosition(languagePoint);
                currentState = OptionsSelectorState.Language;
                break;
            case OptionsSelectorState.Language:
                ChangePosition(displayPoint);
                currentState = OptionsSelectorState.Display;
                break;
            case OptionsSelectorState.Display:
                break;
            default:
                break;
        }
    }
    public void ChangePosition(Vector2 position)
    {
        selector.gameObject.transform.position = position;
    }
    public void CloseOptions()
    {
        menuButtonManager.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ChooseOptions()
    {
        switch (currentState)
        {
            case OptionsSelectorState.Sound:
                TurnSound();
                break;
            case OptionsSelectorState.Language:
                SetLanguage();
                break;
            case OptionsSelectorState.Display:
                ChangeDisplay();
                break;
            default:
                break;
        }
    }
    public void TurnSound()
    {
        print("sound");
    }
    public void SetLanguage()
    {
        print("language");
    }
    public void ChangeDisplay()
    {
        displayMenu.SetActive(true);
    }
}
enum OptionsSelectorState
{
    Sound,
    Language,
    Display
}
