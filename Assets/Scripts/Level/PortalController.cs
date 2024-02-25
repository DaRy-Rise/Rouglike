using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerStats>().transform;
    }
    public void OpenPortal()
    {
        Vector3 spawnPosition = new Vector3(player.position.x + 1.5f, player.position.y) + transform.forward;
        Instantiate(Resources.Load<GameObject>($"Prefab/Portal/Level/{ChoosePortal()}"), spawnPosition, player.rotation);
    }
    private string ChoosePortal()
    {
        switch (GlobalStat.mainMaster) 
        {
            case "sword":
                return "Red_level_portal";
            case "magic":
                return "Blue_level_portal";
            case "throw":
                return "Green_level_portal";
            default:
                return "";
        }
    }
}
