using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterCard : MonoBehaviour
{
    public Transform target;
    Vector3 movingVector;
    public float speed = 10;
    public int damage = 10;
    //bool returning = false;


    void Start()
    {
        movingVector = (target.position - transform.position).normalized;
        Destroy(gameObject, 6);
    }

    void Update()
    {
        transform.Translate(movingVector * speed * Time.deltaTime);
        // Ele vai descer?

        //if (transform.position.z <= 0 && returning == false)
        //{
           // movingVector = movingVector + new Vector3 (0,-1,0);
          //  returning = true;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
        collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
        collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
        collision.gameObject.GetComponent<EnemyStats>().Hurt();
        }
    }
}
