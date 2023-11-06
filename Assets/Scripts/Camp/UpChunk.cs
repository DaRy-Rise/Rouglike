using UnityEngine;

public class UpChunk : Chunk
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerMovement.lastMovedVector.y < 0)
            {
                chunkManager.ChangeChunk(0);
            }
        }
    }
}
