using System;
using UnityEngine;


public class DialogSystem : MonoBehaviour
{
    public static Action onPressE;
    [SerializeField]
    private GameObject dialogBox, masterFace;
    private bool isBoxOpen;

    void Start()
    {
        dialogBox.SetActive(false);
        masterFace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartDialog(Sprite masterFace)
    {
        if (!isBoxOpen)
        {
            dialogBox.SetActive(true);
            this.masterFace.GetComponent<SpriteRenderer>().sprite = masterFace;
            this.masterFace.SetActive(true);
            print("Hello");
            isBoxOpen = true;
        }
    }

    public void StopDialog()
    {
        isBoxOpen = false;
        dialogBox.SetActive(false);
        masterFace.SetActive(false);
    }
}