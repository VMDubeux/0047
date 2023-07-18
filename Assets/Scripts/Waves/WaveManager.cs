using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject [] creeps; 
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountUI;
    public int creepCount;
    int creepIndex, waveIndex = 0;
    public float spawnRate=1;
    void Start()
    {
        waveCountUI.text = "Wave 0";
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CreepSpawn();
            waveIndex++;
            waveCountUI.text = "Wave " + waveIndex.ToString();
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
