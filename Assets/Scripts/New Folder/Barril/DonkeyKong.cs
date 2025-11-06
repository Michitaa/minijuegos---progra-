using UnityEngine;
using System;

public class DonkeyKong : MonoBehaviour
{
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private float spawnRate = 2f;

    private Func<float> GetSpawnTime;

    private void Start()
    {
        GetSpawnTime = () => { return spawnRate; };
        InvokeRepeating("SpawnBarrel", 1f, GetSpawnTime.Invoke());
    }

    private void SpawnBarrel()
    {
        if (barrelPrefab != null)
        {
            Instantiate(barrelPrefab, transform.position, Quaternion.identity);
        }
    }
}