using UnityEngine;

public class MainChunk : Chunk
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerMovement.lastMovedVector.x < 0)
            {
                chunkManager.ChangeChunk(1);
            }
            else if (playerMovement.lastMovedVector.x > 0)
            {
                chunkManager.ChangeChunk(2);
            }
            else if (playerMovement.lastMovedVector.y > 0)
            {
                chunkManager.ChangeChunk(3);
            }
        }
    }
}