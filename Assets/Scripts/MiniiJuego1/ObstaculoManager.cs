using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaculos; 
    public Transform[] spawnPoints;     
    public float spawnInterval = 2f;
    public float obstacleSpeed = 3f;
    public float difficultyIncreaseRate = 0.5f;
    public float maxSpeed = 10f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(IncreaseDifficulty());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
           
            Transform punto = spawnPoints[Random.Range(0, spawnPoints.Length)];

           
            GameObject prefab = obstaculos[Random.Range(0, obstaculos.Count)];

            GameObject obj = Instantiate(prefab, punto.position, Quaternion.identity);
            
            Obstacle obstacleScript = obj.GetComponent<Obstacle>();
            if (obstacleScript != null)
            {
                obstacleScript.speed = obstacleSpeed;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        while (obstacleSpeed < maxSpeed)
        {
            yield return new WaitForSeconds(10f);
            obstacleSpeed += difficultyIncreaseRate;
        }
    }
}