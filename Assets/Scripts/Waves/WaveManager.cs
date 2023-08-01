using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject [] creeps; 
    public Transform [] spawnPoints;
    public TextMeshProUGUI waveCountUI;
    public int creepCount;
    int creepIndex, waveIndex = 0;
    public float spawnRate=1;
    bool wavebool = true;
    void Start()
    {
        waveCountUI.text = "Wave 0";
        Invoke("CreepSpawn", 10);
    }
    void Update()
    {
        if(waveIndex >= 19)
        {
            SceneManager.LoadScene("Vitoria");
        }
    }

    void CreepSpawn()
    {
        for (int i = 0; i < creepCount*2; i++)
        {
            Invoke("StartCS", i * spawnRate);
        }
            waveIndex++;
            waveCountUI.text = "Wave " + waveIndex.ToString();
            if(wavebool)
            {
            wavebool = false;
            StartCoroutine(NextWave());
            }
    }

    void StartCS()
    {
        for (int i = 0; i < creeps.Length; i++)
        {
        int r = Random.Range(0,spawnPoints.Length - 1);
        Instantiate(creeps[i], spawnPoints[r].position, Quaternion.identity);
        }
    }
    void IncreaseCreepCount()
    {
        creepCount++;
        spawnRate -= 0.02f;
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSecondsRealtime(10 + (creepCount*2*spawnRate));
        IncreaseCreepCount();
        wavebool = true;
        CreepSpawn();
    }
}
