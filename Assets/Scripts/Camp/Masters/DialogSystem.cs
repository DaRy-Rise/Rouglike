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
    private List<TextMeshPro> phrases = new List<TextMeshPro>();
    private int numberOfChoosenPhrase;

    void Start()
    {
        dialogBox.SetActive(false);
        masterFace.SetActive(false);
        foreach (var item in phrases)
        {
            item.enabled = false;
        }
    }

    void Update()
    {
        if (isBoxOpen)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (numberOfChoosenPhrase == 0 )
                {
                    phrases[numberOfChoosenPhrase].color = Color.white;
                    numberOfChoosenPhrase = phrases.Count - 1;
                    phrases[numberOfChoosenPhrase].color = Color.red;
                }
                else
                {
                    phrases[numberOfChoosenPhrase].color = Color.white;
                    numberOfChoosenPhrase--;
                    phrases[numberOfChoosenPhrase].color = Color.red;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (numberOfChoosenPhrase >= phrases.Count - 1)
                {
                    phrases[numberOfChoosenPhrase].color = Color.white;
                    numberOfChoosenPhrase = 0;
                    phrases[numberOfChoosenPhrase].color = Color.red;
                }
                else
                {
                    phrases[numberOfChoosenPhrase].color = Color.white;
                    numberOfChoosenPhrase++;
                    phrases[numberOfChoosenPhrase].color = Color.red;
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                ChoosePhrase();
            }
            if (isCloseDialog)
            {
                StopDialog();
                numberOfChoosenPhrase = 0;
                isCloseDialog = false;
            }
        }
    }
    public void StartDialog(Sprite masterFace)
    {
        if (!isBoxOpen)
        {
            dialogBox.SetActive(true);
            this.masterFace.GetComponent<SpriteRenderer>().sprite = masterFace;
            this.masterFace.SetActive(true);
            isBoxOpen = true;
            foreach (var item in phrases)
            {
                item.enabled = true;
            }
            phrases[0].color = Color.red;
            Time.timeScale = 0f;
        }
    }

    public void StopDialog()
    {
        if (isBoxOpen)
        {
            dialogBox.SetActive(false);
            masterFace.SetActive(false);
            foreach (var item in phrases)
            {
                item.color = Color.white;
            }
            Time.timeScale = 1f;
            isBoxOpen = false;
        }
    }
    private void ChooseNumberOfPhrase()
    {
        if (numberOfChoosenPhrase > phrases.Count)
        {
            numberOfChoosenPhrase = 0;
        }
        else
        {
            numberOfChoosenPhrase++;
        }
    }
    private void ChoosePhrase()
    {
        switch (numberOfChoosenPhrase) 
        {
            case 0:
                print("0");
                break; 
            case 1:
                print("1");
                break;
            default: 
                break;
        }
    }
}