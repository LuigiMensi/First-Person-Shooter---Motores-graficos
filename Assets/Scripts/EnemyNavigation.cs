using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using StarterAssets;
using Unity.VisualScripting;
public class EnemyNavigation : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public NavMeshAgent agent;

    public Transform target;

    public Animator enemyAnimator;



    public bool isDead = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdateTarget", 3f, .2f);

        enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) 
        {
            return; 
        }
    }
    
    private void UpdateTarget()
    {
        agent.destination = target.position;

        if (agent.velocity.magnitude > 0.1)
        {
            enemyAnimator.SetBool("IsMoving", true);
        }
        else
        {
            enemyAnimator.SetBool("IsMoving", false);
        }

    }

    public void Die()
    {

        
        Debug.Log("Enemy is Dead.");
        enemyAnimator.SetTrigger("Die");
        agent.isStopped = true;
        isDead = true;
    }

    }

