using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public static Action onPressE;
    [SerializeField]
    private GameObject dialogBox, masterFace;
    [HideInInspector]
    public static bool isBoxOpen;
    public static bool isCloseDialog = false;
    [SerializeField]
    private List<TextMeshProUGUI> listOfPhrases = new List<TextMeshProUGUI>();
    private int numberOfChoosenPhrase = 1;
    private Animation anim;
    private bool isMainMaster;
    private KindOfMasters kindOfMasters;
    [SerializeField]
    private ParsingJson reader;
    private Phrases phrases;
    private string phrasesJsonPath = "Assets/Resources/Json/masterPhrases.json";
    private string swordImprovePhrases = "Улучшить меч", magicImprovePhrases = "Прокачать магию", throwImprovePhrases = "Научиться метко стрелять";
    [SerializeField]
    private TreeOfAbilityManager treeOfAbilityManager;

    private void Awake()
    {
        phrases = reader.GetInfo<Phrases>(phrasesJsonPath);
    }
    void Start()
    {
        dialogBox.SetActive(false);
        masterFace.SetActive(false);
        foreach (var item in listOfPhrases)
        {
            item.enabled = false;
        }
        anim = dialogBox.GetComponent<Animation>();
    }

    void Update()
    {
        if (isBoxOpen)
        {
            ChooseNumberOfPhrase();
           
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                ChoosePhrase();
            }
        }
    }
    public void StartDialog(Sprite masterFace, KindOfMasters kindOfMasters, bool isMain)
    {
        if (!isBoxOpen)
        {
            dialogBox.SetActive(true);
            anim.Play("DialogBoxAppear");
            this.masterFace.GetComponent<SpriteRenderer>().sprite = masterFace;
            this.masterFace.SetActive(true);
            isBoxOpen = true;
            foreach (var item in listOfPhrases)
            {
                item.enabled = true;
            }
            listOfPhrases[1].color = Color.red;
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            isMainMaster = isMain;
            this.kindOfMasters = kindOfMasters;
            SetPhrases(this.kindOfMasters);
        }
    }

    public void StopDialog()
    {
        if (isBoxOpen)
        {
            anim.Play("DialogBoxDisappear");
            Invoke("SetBoxUnactive", 0.25f);
            foreach (var item in listOfPhrases)
            {
                item.color = Color.white;
                item.text = "";
            }
            FindAnyObjectByType<PlayerMovement>().enabled = true;
            isBoxOpen = false;
            numberOfChoosenPhrase = 1;
        }
    }
    private void SetBoxUnactive()
    {
        dialogBox.SetActive(false);
        masterFace.SetActive(false);
    }
    private void ChooseNumberOfPhrase()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (numberOfChoosenPhrase == 1)
            {
                listOfPhrases[numberOfChoosenPhrase].color = Color.white;
                numberOfChoosenPhrase = listOfPhrases.Count - 1;
                listOfPhrases[numberOfChoosenPhrase].color = Color.red;
            }
            else
            {
                listOfPhrases[numberOfChoosenPhrase].color = Color.white;
                numberOfChoosenPhrase--;
                listOfPhrases[numberOfChoosenPhrase].color = Color.red;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (numberOfChoosenPhrase >= listOfPhrases.Count - 2 && !isMainMaster)
            {
                listOfPhrases[numberOfChoosenPhrase].color = Color.white;
                numberOfChoosenPhrase = 1;
                listOfPhrases[numberOfChoosenPhrase].color = Color.red;
            }
            else if (numberOfChoosenPhrase >= listOfPhrases.Count - 1)
            {
                listOfPhrases[numberOfChoosenPhrase].color = Color.white;
                numberOfChoosenPhrase = 1;
                listOfPhrases[numberOfChoosenPhrase].color = Color.red;
            }
            else
            {
                listOfPhrases[numberOfChoosenPhrase].color = Color.white;
                numberOfChoosenPhrase++;
                listOfPhrases[numberOfChoosenPhrase].color = Color.red;
            }
        }
    }
    private void ChoosePhrase()
    {
        switch (numberOfChoosenPhrase)
        {
            case 1:
                treeOfAbilityManager.OpenTreeOfAbility();
                break;
            case 2:
                if (isMainMaster)
                {
                    foreach (var item in FindObjectsOfType<Master>())
                    {
                        if (item.kindOfMasters == kindOfMasters)
                        {
                            item.OpenPortal();
                        }
                    }
                    StopDialog();
                }
                else
                {
                    StopDialog();
                }
                break;
            case 3:
                StopDialog();
                break;
            default:
                break;
        }
    }

    private void SetPhrases(KindOfMasters kindOfMasters)
    {
        switch (kindOfMasters)
        {
            case KindOfMasters.Sword:
                listOfPhrases[0].text = phrases.swordMasterPhrases.level1;
                listOfPhrases[1].text = swordImprovePhrases;
                break;
            case KindOfMasters.Magic:
                listOfPhrases[0].text = phrases.magicMasterPhrases.level1;
                listOfPhrases[1].text = magicImprovePhrases;
                break;
            case KindOfMasters.Throwing:
                listOfPhrases[0].text = phrases.throwMasterPhrases.level1;
                listOfPhrases[1].text = throwImprovePhrases;
                break;
            default:
                break;
        }
        if (isMainMaster)
        {
            listOfPhrases[2].text = "Открыть портал";
            listOfPhrases[3].text = "Ничего";
        }
        else
        {
            listOfPhrases[2].text = "Ничего";
        }
    }
}