using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField]
    private Chunk mainChunk, leftChunk, rightChunk, upChunk;

    public void ChangeChunk(int chunkId)
    {
        switch (chunkId)
        {
            case 0:
                mainChunk.SetChunk();
                break;
            case 1:
                leftChunk.SetChunk();
                break;
            case 2:
                rightChunk.SetChunk();
                break;
            case 3:
                upChunk.SetChunk();
                break;
            default:
                break;
        }
    }
}