using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightChunk : Chunk
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerMovement.lastMovedVector.x < 0)
            {
                chunkManager.ChangeChunk(0);
            }
        }
    }
}
