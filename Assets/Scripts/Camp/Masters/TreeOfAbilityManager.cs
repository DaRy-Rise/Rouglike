using UnityEngine;

public class TreeOfAbilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject treeOfAbility, dialogBox;
    public static bool isTreeOpen;
    //string pulsePath = "Prefab/Camp/Ability/Sword/pulse.prefab";
    //string destroyedPath = "Prefab/Camp/Ability/Sword/destroyed.prefab";
    [SerializeField]
    Animator anim;
    [SerializeField]
    GameObject[] points;

    void Start()
    {
        treeOfAbility.SetActive(false);
    }
    public void OpenTreeOfAbility(KindOfMasters kindOfMasters)
    {
        isTreeOpen = true;
        DialogSystem.isBoxOpen = false;
        treeOfAbility.SetActive(true);
    }
    public void CloseTree()
    {
        DialogSystem.isBoxOpen = true;
        isTreeOpen = false;
        treeOfAbility.SetActive(false);
    }
    private void DrawAbility()
    {
 
    }
}