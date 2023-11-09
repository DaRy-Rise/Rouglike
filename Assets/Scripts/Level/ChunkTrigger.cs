using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mapController;
    public ChunkOnLevel targetMap;

    void Start()
    {
        mapController = FindAnyObjectByType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapController.currentChunk = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("ChunkTrigger.OnTriggerExit2D targetMap: " + targetMap);
        if (collision.CompareTag("Player"))
        {
            if (mapController.currentChunk == targetMap)
            {
                mapController.currentChunk = null;
            }
        }
    }
}