using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    public GameObject[] gatePrefabs; // Prefabs ot the gates that will spawn
    public GameObject coin; // coin that we collect

    private void Start()
    {
        SpawnThings(); // method that spawns the gates at the start
    }

    public void SpawnThings()
    {
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(1.349f, 2.211f, -0.121f), Quaternion.identity); // We are spawning a random gate from our prefsbs to a set location
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(2.349f, 2.211f, -0.121f), Quaternion.identity);

        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(1.347f, 2.211f, 12.84f), Quaternion.identity);
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(2.342f, 2.211f, 12.84f), Quaternion.identity);

        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(1.347f, 2.211f, 25.91f), Quaternion.identity);
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(2.342f, 2.211f, 25.91f), Quaternion.identity);
       
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(1.347f, 2.211f, 37.92f), Quaternion.identity);
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(2.342f, 2.211f, 37.92f), Quaternion.identity);
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(1.347f, 2.211f, 43.854f), Quaternion.identity);
        Instantiate(gatePrefabs[Random.Range(0, gatePrefabs.Length)], new Vector3(2.342f, 2.211f, 43.854f), Quaternion.identity);

        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity); // sawning the coins on random spots of the level
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
        Instantiate(coin, new Vector3(Random.Range(1.16f, 3f), 2, Random.Range(-3, 47.834f)), Quaternion.identity);
    }
}
