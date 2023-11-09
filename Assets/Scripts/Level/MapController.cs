using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private List<ChunkOnLevel> terrainChunks;
    private PlayerMovement playerMovement;
    private Vector3 noTerrainPosition;
    private ChunkOnLevel latestChunk;
    [HideInInspector]
    public ChunkOnLevel currentChunk;
    public float checkerRadius;
    public GameObject player;
    public LayerMask terrainMask;
    [Header("Optimization")]
    public List<ChunkOnLevel> spawnedChunks;
    public float maxOpDist;
    private float opDist;
    private float optimizerCooldown;
    private float optimizerCooldownDur;
    private KindOfDirection kindOfDirection;

    void Start()
    {
        terrainChunks = Resources.LoadAll<ChunkOnLevel>("Prefab/Chunks").ToList();
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
        ShuffleList();
        ChooseChunkToSpawn();
        spawnedChunks.Add(latestChunk);
    }
    private void ShuffleList()
    {
        for (int i = 0; i < terrainChunks.Count; i++)
        {
            ChunkOnLevel tmp = terrainChunks[0];
            terrainChunks.RemoveAt(0);
            terrainChunks.Insert(new System.Random().Next(terrainChunks.Count), tmp);
        }
    }
    private void ChooseChunkToSpawn()
    {
        if (currentChunk.RoadUp)
        {
            if (kindOfDirection == KindOfDirection.Up)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (chunk.RoadDown || chunk.RoadUpDown || chunk.Random)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (kindOfDirection == KindOfDirection.Down)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.RoadUp)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else
            {
                int rand = Random.Range(0, terrainChunks.Count);
                latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
            }
        }
        else if (currentChunk.RoadDown)
        {
            if (kindOfDirection == KindOfDirection.Up)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.RoadDown)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (kindOfDirection == KindOfDirection.Down)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (chunk.RoadUp || chunk.RoadUpDown || chunk.Random)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else
            {
                int rand = Random.Range(0, terrainChunks.Count);
                latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
            }
        }
        else if (currentChunk.RoadUpDown)
        {
            foreach (var chunk in terrainChunks)
            {
                if (chunk.RoadDown || chunk.RoadUp || chunk.RoadUpDown)
                {
                    latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                    break;
                }
            }
        }
        else if (currentChunk.RoadRight)
        {
            if (kindOfDirection == KindOfDirection.Right)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (chunk.RoadLeft || chunk.RoadLeftRight || chunk.Random)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (kindOfDirection == KindOfDirection.Left)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.RoadRight)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else
            {
                int rand = Random.Range(0, terrainChunks.Count);
                latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
            }
        }
        else if (currentChunk.RoadLeft)
        {
            if (kindOfDirection == KindOfDirection.Right)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.RoadLeft)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (kindOfDirection == KindOfDirection.Left)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (chunk.RoadRight || chunk.RoadLeftRight || chunk.Random)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else
            {
                int rand = Random.Range(0, terrainChunks.Count);
                latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
            }
        }
        else if (currentChunk.RoadLeftRight)
        {
            foreach (var chunk in terrainChunks)
            {
                if (chunk.RoadLeft || chunk.RoadRight || chunk.RoadLeftRight)
                {
                    latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                    break;
                }
            }
        }
        else
        {
            foreach (var chunk in terrainChunks)
            {
                if (!chunk.Continue)
                {
                    latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                    break;
                }
            }
        }

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
        foreach (ChunkOnLevel chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.enabled = false;
            }
            else
            {
                chunk.enabled = true;
            }
        }
    }
}