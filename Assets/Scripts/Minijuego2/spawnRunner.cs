using UnityEngine;

public class spawnRunner : MonoBehaviour
{
   public GameObject[] obstaculos;
    public float intervalo = 2f;
    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= intervalo)
        {
            int index = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[index], transform.position, Quaternion.identity);
            tiempo = 0;
        }
    }
}
