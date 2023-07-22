using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float interacionDistance;
    public GameObject actionCursor;


    private GameObject interacionObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region MEUS MÉTODOS

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

    public void ActiveCursos(GameObject obj)
    {

        interacionObject = obj;
        if (Vector2.Distance(CoreGame._instance.playerMovement.transform.position, interacionObject.transform.position) <= interacionDistance)
        {
            actionCursor.transform.position = obj.transform.position;
            actionCursor.SetActive(true);

        }
        else
        {
            DisableCursor();
        }
    }

    public void DisableCursor()
    {
        actionCursor.SetActive(false);
        interacionObject = null;
    }


    #endregion
}
