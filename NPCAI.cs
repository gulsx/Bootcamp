using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{

    //[SerializeField] GameObject destinationPoint;

    private Animator _anim;
    public NavMeshAgent _agent;
    [SerializeField] Transform _player;
    public LayerMask ground, player;

    public Vector3 destinationPoint;
    private bool destinationPointSet;
    public float walkPointRange;

    //public float timeBetweenAttacks;
    //private bool alreadyAttacked;
    //public GameObject sphere;

    public float sightRange; /*attackRange*/
    public bool playerInSightRange; /*playerInAttackRange*/


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
        // playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);
        _anim.SetFloat("Speed", _agent.velocity.magnitude);

        if (!playerInSightRange /*&& playerInAttackRange*/) Patroling();
        if (playerInSightRange /*&& playerInAttackRange*/) ChasePlayer();
        if (playerInSightRange /*&& playerInAttackRange*/) AttackPlayer();
    }

    void Patroling()
    {
       // if(!destinationPointSet)
       // {
       //     SearchWalkPoint();
       // }
       // 
       // if(destinationPointSet)
       // {
       //     _agent.SetDestination(destinationPoint);
       // }
       //
       // Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
       // if (distanceToDestinationPoint.magnitude < 1.0f)
       // {
       //     destinationPointSet = false;
       // }
    }

    void SearchWalkPoint()
    {
       // float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
       // float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
       //
       // destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y,
       //     transform.position.z + randomZ);
       // 
       // if(Physics.Raycast(destinationPoint, -transform.up, 2.0f, ground))
       // {
       //     destinationPointSet = true;
       // }
    }

    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    void AttackPlayer()
    {
       // _agent.SetDestination(transform.position);
       //
       // transform.LookAt(_player);
       //
       // if(!alreadyAttacked)
       // {
       //     alreadyAttacked = true;
       // }
    }



}
