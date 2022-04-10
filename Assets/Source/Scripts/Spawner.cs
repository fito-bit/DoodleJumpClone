using System;
using Supyrb;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool simplePlPool;
    [SerializeField] private Pool movingPlPool;
    [SerializeField] private Pool destroyablePlPool;
    [SerializeField] private float platformsCountForSpawn;
    [SerializeField] private float maxX;
    
    private float prevSpawnX = 0;

    private void Awake()
    {
        Signals.Get<SpawnPlatformsSignal>().AddListener(Spawn);
    }

    void Spawn(float playerY)
    {
        float y = playerY + 0.5f;
        for (int i = 0; i < platformsCountForSpawn; i++)
        {
            float x = Random.Range(-maxX, maxX);
            while (Math.Abs(x - prevSpawnX)<=1f)
            {
                x = Random.Range(-maxX, maxX);
            }
            GameObject platform = GetPlatform();
            platform.transform.position = new Vector3(x, y, 0);
            platform.SetActive(true);
            y += 0.5f;
        }
    }

    GameObject GetPlatform()
    {
        int randomValue = Random.Range(0, 1000);
        if (randomValue > 500&& randomValue<750)
        {
            return movingPlPool.GetObject();
        }else if (randomValue > 900)
        {
            return destroyablePlPool.GetObject();
        }
        return simplePlPool.GetObject();
    }
}
