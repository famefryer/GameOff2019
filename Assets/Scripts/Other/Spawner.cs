using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monster;
    public float startMonsterSpawnTime;
    public float minDelayMonsterSpawnTime;
    public float decreaseMonsterSpawnTime;

    private float timeBtwMonsterSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwMonsterSpawnTime = startMonsterSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwMonsterSpawnTime <= 0)
        {
            timeBtwMonsterSpawnTime = startMonsterSpawnTime;
            Instantiate(monster,transform.position,Quaternion.identity);
            if(startMonsterSpawnTime > minDelayMonsterSpawnTime)
                startMonsterSpawnTime -= decreaseMonsterSpawnTime;
        }
        else
        {
            timeBtwMonsterSpawnTime -= Time.deltaTime;
        }
    }
}
