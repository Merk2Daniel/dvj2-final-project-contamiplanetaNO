using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objects;

    public float timeSpawn = 1;
    public float repeatSpawnRate = 3; //tiempo en que se genera un nuevo objeto
    
    public Transform xRangeLeft;
    public Transform xRangeRight;

    public Transform yRangeUp;
    public Transform yRangeDown;

    void Start()
    {
        InvokeRepeating("SpawnObject", timeSpawn, repeatSpawnRate);
    }

    public void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);
        GameObject obj = Instantiate(objects[Random.Range(0, objects.Length)], spawnPosition, gameObject.transform.rotation);
    }

}
