using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;
    private Vector3 targetPosition;
    private Transform Target;
    public GameObject firePS, waterPS, thunderPS;
    public bool fireB, waterB, thunderB;
    public float speed = 70f;
    public float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        targetPosition = _target.position;
        Target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = targetPosition - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    #region // MEUS M�TODOS
    void HitTarget()
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(Target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
                SlowDownEnemy(collider.transform);
            }
            if(fireB)
            
                Instantiate(firePS,transform.position, Quaternion.identity);
            
            else if (waterB)
            
                Instantiate(waterPS, transform.position, Quaternion.identity);
            
            else if (thunderB)
                Instantiate(thunderPS, transform.position, Quaternion.identity);
        }
    }

    void Damage(Transform other)
    {
        other.gameObject.GetComponent<EnemyStats>().myHealth -= damage;
        other.gameObject.GetComponent<EnemyStats>().Hurt();
        // Ativar �rea de fogo ou qualquer outra a��o ao causar dano
    }

    void SlowDownEnemy(Transform enemyTransform)
    {
        EnemyStats enemyStats = enemyTransform.GetComponent<EnemyStats>();
        if (enemyStats != null)
        {
            enemyStats.SlowDown();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    #endregion
}
