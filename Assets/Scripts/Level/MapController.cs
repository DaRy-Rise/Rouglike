using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private List<GameObject> terrainChunks;
    private PlayerMovement playerMovement;
    private Vector3 noTerrainPosition;
    private GameObject latestChunk;
    [HideInInspector]
    public GameObject currentChunk;
    public float checkerRadius;
    public GameObject player;
    public LayerMask terrainMask;
    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    public float maxOpDist;
    private float opDist;
    private float optimizerCooldown;
    private float optimizerCooldownDur;
    private KindOfDirection kindOfDirection;

    void Start()
    {
        terrainChunks = Resources.LoadAll<GameObject>("Prefab/Chunks").ToList();
        playerMovement = FindAnyObjectByType<PlayerMovement>();      
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    private void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        if (playerMovement.moveDir.x > 0 && playerMovement.moveDir.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RDown").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x < 0 && playerMovement.moveDir.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LDown").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x == 0 && playerMovement.moveDir.y > 0) //up
        {
            kindOfDirection = KindOfDirection.Up;
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LUp").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x == 0 && playerMovement.moveDir.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RDown").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LDown").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x > 0 && playerMovement.moveDir.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x > 0 && playerMovement.moveDir.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RDown").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x < 0 && playerMovement.moveDir.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x < 0 && playerMovement.moveDir.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LDown").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        List<GameObject> chunksToSpawn = ChooseChunkToSpawn();  
        int rand = Random.Range(0, chunksToSpawn.Count);
        latestChunk = Instantiate(chunksToSpawn[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
        chunksToSpawn.Clear();
    }

    private List<GameObject> ChooseChunkToSpawn()
    {
        List<GameObject> chunksAllowedToSpawn = new List<GameObject>(terrainChunks.Count);
        terrainChunks.ForEach((item) =>
        {
            chunksAllowedToSpawn.Add(item);
        });
        chunksAllowedToSpawn.RemoveAll(chunk => chunk.name == currentChunk.name || chunk.name + "(Clone)" == currentChunk.name);
        List<string> chunkTypes = new List<string> { "RDown", "LDown", "Right", "RUp", "LUp", "Left", "Up", "Down" };
        foreach (string chunkType in chunkTypes)
        {
            Transform chunkPosition = currentChunk.transform.Find(chunkType);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(chunkPosition.position, checkerRadius, terrainMask);

            if (colliders.Length > 0)
            {
                chunksAllowedToSpawn.RemoveAll(chunk => chunk.name + "(Clone)" == colliders[0].gameObject.name || chunk.name == colliders[0].gameObject.name);
            }
        }
        return chunksAllowedToSpawn;
    }

    private void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}