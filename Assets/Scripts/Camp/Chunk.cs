using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    protected Camera mainCamera;
    [SerializeField]
    protected GameObject cameraSpawnPoint;
    protected ChunkManager chunkManager;
    protected PlayerMovement playerMovement;
    private void Start()
    {
        chunkManager = FindAnyObjectByType<ChunkManager>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }
    public void SetChunk()
    {
        mainCamera.transform.position = new Vector3(cameraSpawnPoint.transform.position.x, cameraSpawnPoint.transform.position.y, -10);
    }
}