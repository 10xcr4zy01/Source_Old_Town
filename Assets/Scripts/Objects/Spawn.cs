using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private int maxSpawn, time, firstSpawnTimer;
    [SerializeField] private GameObject monsterPrefabs;
    [SerializeField] private GameObject warning;
    float timer;


    int currentSpawn;
    bool isSpawning;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpawn = maxSpawn;
        timer = -firstSpawnTimer;
        isSpawning = true; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time && currentSpawn > 0)
        {
            GameObject monster = Instantiate(monsterPrefabs, transform.position, transform.rotation);
            timer = 0;
            currentSpawn -= 1;
            isSpawning = true;
        }
        if (timer > time - 1 && isSpawning == true && currentSpawn > 0)
        {
            Destroy(Instantiate(warning, new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), transform.rotation), 0.5f);
            isSpawning = false;
        }
    }

}
