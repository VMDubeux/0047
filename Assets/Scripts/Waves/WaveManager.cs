using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject [] creeps; 
    public Transform spawnPoint;
    public int creepCount;
    int creepIndex;
    public float spawnRate=1;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CreepSpawn();
        }
    }

    void CreepSpawn()
    {
        for (int i = 0; i < creepCount; i++)
        {
            Invoke("StartCS", i * spawnRate);
        }
    }

    void StartCS()
    {
        for (int i = 0; i < creeps.Length; i++)
        {
        Instantiate(creeps[i], spawnPoint.position, Quaternion.identity);
        }
    }
}
