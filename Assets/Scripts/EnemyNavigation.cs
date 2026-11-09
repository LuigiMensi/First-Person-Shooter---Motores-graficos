using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
public class EnemyNavigation : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public NavMeshAgent agent;

    public Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        Invoke("UpdateTarget", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void UpdateTarget()
    {
        agent.destination = target.position;
    }



}
