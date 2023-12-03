using UnityEngine;

public class LeftChunk : Chunk
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerMovement.lastMovedVector.x > 0)
            {
                chunkManager.ChangeChunk(0);
            }
        }
    }
}