//Лучше наложить на пустой объект
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{ 
    public GameObject debrisPrefab;
    public int poolSize = 5;
    public float spawnRadius = 20f;
    public float despawnDistance = 19f;
    public float spawnHeightMin = -50f, spawnHeightMax = 50f;
    private List<GameObject> debrisPool = new List<GameObject>();
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject debris = Instantiate(debrisPrefab);
            debris.SetActive(false);
            debrisPool.Add(debris);
        }
    }

    void Update()
    {
        foreach (GameObject debris in debrisPool)
        {
            if (!debris.activeInHierarchy)
            {
                SpawnDebris(debris);
            }
            else
            {
                CheckDespawn(debris);
            }
        }
    }

    void SpawnDebris(GameObject debris)
    {
        Vector3 forwardDirection = player.forward;
        Vector3 randomOffset = Quaternion.Euler(0, Random.Range(-30, 30), 0) * forwardDirection;
        Vector3 spawnPosition = player.position + randomOffset.normalized * Random.Range(spawnRadius * 0.8f, spawnRadius);
        spawnPosition.y = Random.Range(spawnHeightMin, spawnHeightMax);

        debris.transform.position = spawnPosition;
        debris.SetActive(true);
    }

    void CheckDespawn(GameObject debris)
    {
        if (Vector3.Distance(player.position, debris.transform.position) > despawnDistance)
        {
            debris.SetActive(false);
            return;
        }

        Vector3 toDebris = (debris.transform.position - player.position).normalized;
        float dotProduct = Vector3.Dot(player.forward, toDebris);
        if (dotProduct < 0)
        {
            debris.SetActive(false);
        }
    }
}
