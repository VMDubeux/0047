using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    Camera myCamera;
    RaycastHit hit;
    NavMeshAgent navMesh;
    string groundTag = "Ground";
    public float speed = 20;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start() 
    {
        navMesh = GetComponent<NavMeshAgent>();
        myCamera = FindObjectOfType<Camera>();
        navMesh.speed = speed;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.CompareTag(groundTag))
                {
                    navMesh.SetDestination(hit.point);
                }
            }
        }
    }
}