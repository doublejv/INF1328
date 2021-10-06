using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnRate;
    public int waves;
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < waves; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector2(Random.Range(-8.5f, 8.5f), 7), Quaternion.identity); 
        }
    }
}
