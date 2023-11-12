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
                print("right - 1if");
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RUp").position, checkerRadius, terrainMask))
            {
                print("right - 2if");
                print(currentChunk.transform.Find("RUp").position);
                noTerrainPosition = currentChunk.transform.Find("RUp").position;
                SpawnChunk();
            }
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RDown").position, checkerRadius, terrainMask))
            {
                print("right - 3if");
                print(currentChunk.transform.Find("RDown").position);
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
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }
    private void ShuffleList()
    {
        for (int i = 0; i < terrainChunks.Count; i++)
        {
            GameObject tmp = terrainChunks[0];
            terrainChunks.RemoveAt(0);
            terrainChunks.Insert(new System.Random().Next(terrainChunks.Count), tmp);
        }
    }
    /*private void ChooseChunkToSpawn()
    {
        if (currentChunk.GetComponent<ChunkOnLevel>().RoadUp)
        {
            if (kindOfDirection == KindOfDirection.Up)
            {
                if (currentChunk.GetComponent<ChunkOnLevel>().Continue)
                {
                    foreach (var chunk in terrainChunks)
                    {
                        if (chunk.GetComponent<ChunkOnLevel>().RoadDown || chunk.GetComponent<ChunkOnLevel>().RoadUpDown)
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
                        if (chunk.GetComponent<ChunkOnLevel>().RoadDown || chunk.GetComponent<ChunkOnLevel>().RoadUpDown || chunk.GetComponent<ChunkOnLevel>().Random)
                        {
                            latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                            break;
                        }
                    }
                }

            }
            else if (kindOfDirection == KindOfDirection.Down)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.GetComponent<ChunkOnLevel>().RoadUp)
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
        else if (currentChunk.GetComponent<ChunkOnLevel>().RoadDown)
        {
            if (kindOfDirection == KindOfDirection.Up)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.GetComponent<ChunkOnLevel>().RoadDown)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (kindOfDirection == KindOfDirection.Down)
            {
                if (currentChunk.GetComponent<ChunkOnLevel>().Continue)
                {
                    foreach (var chunk in terrainChunks)
                    {
                        if (chunk.GetComponent<ChunkOnLevel>().RoadUp || chunk.GetComponent<ChunkOnLevel>().RoadUpDown)
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
                        if (chunk.GetComponent<ChunkOnLevel>().RoadUp || chunk.GetComponent<ChunkOnLevel>().RoadUpDown || chunk.GetComponent<ChunkOnLevel>().Random)
                        {
                            latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                            break;
                        }
                    }
                }

            }
            else
            {
                int rand = Random.Range(0, terrainChunks.Count);
                latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
            }
        }
        else if (currentChunk.GetComponent<ChunkOnLevel>().RoadUpDown)
        {
            foreach (var chunk in terrainChunks)
            {
                if (chunk.GetComponent<ChunkOnLevel>().RoadDown || chunk.GetComponent<ChunkOnLevel>().RoadUp || chunk.GetComponent<ChunkOnLevel>().RoadUpDown)
                {
                    latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                    break;
                }
            }
        }
        else if (currentChunk.GetComponent<ChunkOnLevel>().RoadRight)
        {
            if (kindOfDirection == KindOfDirection.Right)
            {
                if (currentChunk.GetComponent<ChunkOnLevel>().Continue)
                {
                    foreach (var chunk in terrainChunks)
                    {
                        if (chunk.GetComponent<ChunkOnLevel>().RoadLeft || chunk.GetComponent<ChunkOnLevel>().RoadLeftRight)
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
                        if (chunk.GetComponent<ChunkOnLevel>().RoadLeft || chunk.GetComponent<ChunkOnLevel>().RoadLeftRight || chunk.GetComponent<ChunkOnLevel>().Random)
                        {
                            latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                            break;
                        }
                    }
                }

            }
            else if (kindOfDirection == KindOfDirection.Left)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.GetComponent<ChunkOnLevel>().RoadRight)
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
        else if (currentChunk.GetComponent<ChunkOnLevel>().RoadLeft)
        {
            if (kindOfDirection == KindOfDirection.Right)
            {
                foreach (var chunk in terrainChunks)
                {
                    if (!chunk.GetComponent<ChunkOnLevel>().RoadLeft)
                    {
                        latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (kindOfDirection == KindOfDirection.Left)
            {
                if (currentChunk.GetComponent<ChunkOnLevel>().Continue)
                {
                    foreach (var chunk in terrainChunks)
                    {
                        if (chunk.GetComponent<ChunkOnLevel>().RoadRight || chunk.GetComponent<ChunkOnLevel>().RoadLeftRight)
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
                        if (chunk.GetComponent<ChunkOnLevel>().RoadRight || chunk.GetComponent<ChunkOnLevel>().RoadLeftRight || chunk.GetComponent<ChunkOnLevel>().Random)
                        {
                            latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                            break;
                        }
                    }
                }

            }
            else
            {
                int rand = Random.Range(0, terrainChunks.Count);
                latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
            }
        }
        else if (currentChunk.GetComponent<ChunkOnLevel>().RoadLeftRight)
        {
            foreach (var chunk in terrainChunks)
            {
                if (chunk.GetComponent<ChunkOnLevel>().RoadLeft || chunk.GetComponent<ChunkOnLevel>().RoadRight || chunk.GetComponent<ChunkOnLevel>().RoadLeftRight)
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
                if (!chunk.GetComponent<ChunkOnLevel>().Continue)
                {
                    latestChunk = Instantiate(chunk, noTerrainPosition, Quaternion.identity);
                    break;
                }
            }
        }

    }*/

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