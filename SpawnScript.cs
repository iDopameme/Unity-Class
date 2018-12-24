using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject enemy;
    public float spawnDelay;   //amount of time to wait until you spawn again
    private float nextSpawnTime;  //when is the next time I should spawn an enemy? // Enemy only needs to be spawned once. All enemies spawn at same time no delay needed [Richard]

    // Use this for initialization
	void Start () {
        spawnDelay = 10;
        nextSpawnTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldISpawn())
        {
            SpawnTheThing();
        }
	}

    private bool shouldISpawn()
    {
        return Time.time >= nextSpawnTime;
    }

    private void SpawnTheThing()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(enemy, this.transform.position, this.transform.rotation);        
    }

}
