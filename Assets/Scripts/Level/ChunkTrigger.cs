using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mapController;
    public GameObject targetMap;

    void Start()
    {
        mapController = FindAnyObjectByType<MapController>();
        targetMap.GetComponent<ChunkOnLevel>().x = 0;
        targetMap.GetComponent<ChunkOnLevel>().y = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //print("OnTriggerStay2D " + targetMap);
            mapController.currentChunk = targetMap;
        }
    }
   private void OnTriggerExit2D(Collider2D collision)
    {
        //print("OnTriggerExit2D");
        if (collision.CompareTag("Player"))
        {
            if (mapController.currentChunk == targetMap)
            {
                mapController.currentChunk = null;
            }
        }
    }
}