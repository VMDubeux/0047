using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region MEUS M�TODOS

    private void OnTriggerEnter(Collider other)
    {
        TowerTakeDamage(other);
    }

    void TowerTakeDamage(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            
            Destroy(other.gameObject);
        }
    }


    #endregion
}
