using UnityEngine;

public class MasterBuffController : MonoBehaviour
{
    [SerializeField]
    protected ImprovePlate improvePlate;
    private SpriteRenderer panelSpriteRenderer;
    [SerializeField]
    private GameObject swordMaster, kataMaster, potionMaster;
    public static bool isActive;

    private void Start()
    {
        CheckMasters();
        panelSpriteRenderer = improvePlate.GetComponent<SpriteRenderer>();
        panelSpriteRenderer.enabled = false;
    }
    public void ShowImprovePlate(KindOfMasters master, KindOfBuff buff)
    {
        panelSpriteRenderer.enabled = true;
        improvePlate.Spawn(master, buff);
        isActive = false;
    }
    public void ShowPotionQTEPlate()
    {
        panelSpriteRenderer.enabled = true;
        improvePlate.SpawnPotionQTE();
        isActive = false;
    }
    private void CheckMasters()
    {
        if (GlobalStat.swordMas > 0)
        {
            swordMaster.SetActive(true);
        }
        else
        {
            swordMaster.SetActive(false);
        }
        if (GlobalStat.kataMas > 0)
        {
            kataMaster.SetActive(true);
        }
        else
        {
            kataMaster.SetActive(false);
        }
        if (GlobalStat.potionMas > 0)
        {
            potionMaster.SetActive(true);
        }
        else
        {
            potionMaster.SetActive(false);
        }
    }
}