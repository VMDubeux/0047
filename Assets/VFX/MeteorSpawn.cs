using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private int meteorAmount;
    [SerializeField] private float radius;
    float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(meteorAmount <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if(timeToSpawn <= 0)
            {
                float rad = Random.Range(-radius, radius);
                Vector3 pos = new Vector3(transform.position.x + rad, transform.position.y, transform.position.z + rad);
                Instantiate(meteor, pos, transform.rotation);
                timeToSpawn = maxTime;
                meteorAmount--;
            }
            else
            {
                timeToSpawn -= Time.deltaTime;
            }
        }
    }
}
