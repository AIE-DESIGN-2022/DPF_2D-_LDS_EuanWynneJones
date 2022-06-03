using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    MoveTowardsBase,
    MoveTowardsTarget,
    AttackTarget
}




public class EnemyNavigation : MonoBehaviour
{
    public float distanceReachedThreashold;
    public float playerChaseThreashold;
    public float attackRange;



    public EnemyState enemyState;
    private Vector3 _targetSightedPosition;

    private GameObject _target;


    public Transform[] patrolPoints;
    private NavMeshAgent _agent;


    private int _currentDestination;
    private int _nextLocation;

    public EnemyWeaponManager enemyCombat;


    // Start is called before the first frame update
    void Start()
    {
        enemyCombat = GetComponent<EnemyWeaponManager>();

        enemyState = EnemyState.MoveTowardsBase;
        _target = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _currentDestination = -1;
        _nextLocation = 0;


        SetAgentPatrolDesination();


    }


    // Update is called once per frame
    void Update()
    {

        
        float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[_currentDestination].position);
        float distanceToPlayer = Vector3.Distance(transform.position, _target.transform.position);

        if (enemyState == EnemyState.MoveTowardsBase)
        {

            if (distanceToTarget <= distanceReachedThreashold)
            {

                SetAgentPatrolDesination();
            }

            //checking if the player has reached the enemies sighted threashold
            if (distanceToPlayer <= playerChaseThreashold)
            {

                //changes the enemys state to playerSighted
                enemyState = EnemyState.MoveTowardsTarget;

                //stores this data in to the player sighted position
                _targetSightedPosition = _target.transform.position;
            }

        }

        //checked if player is close enough to be spotted 
        else if (enemyState == EnemyState.MoveTowardsTarget)
        {
            //setting the enemy destination to the players most recently sighted location
            SetPlayerSightedDestination();

            //attack range should not be breached before player is sighted so statements are nested

            //if player is within attack range set the state to attack the player 
            if (Vector3.Distance(transform.position, _target.transform.position) <= attackRange)
            {
                enemyState = EnemyState.AttackTarget;
            }

            //if the player outruns the enemies sight range the enemy will return to patrol mode 
            if (Vector3.Distance(transform.position, _targetSightedPosition) <= distanceReachedThreashold)
            {
                enemyState = EnemyState.MoveTowardsBase;

                //manually assigning the current patrol point to the enemies next location
                _agent.SetDestination(patrolPoints[_currentDestination].position);
            }
        }



        //checking if the enemies state is to attack
        if (enemyState == EnemyState.AttackTarget)
        {

            //check to see if player is outstide attack range, if it is we set state to player sighted (enemy chases player)
            if (Vector3.Distance(transform.position, _target.transform.position) > attackRange)
            {
                enemyState = EnemyState.MoveTowardsTarget;
            }

            //otherwise the player is in range, and the enemy can attack. sets the enemies location its own position to make it stop
            else
            {
                _agent.SetDestination(transform.position);
                _agent.transform.LookAt(_target.transform.position);

                //innitialise the enemy attack coroutine 
                if (enemyCombat.canAttack)
                {
                    StartCoroutine(enemyCombat.Attack());
                }
            }
        }

    }




    void SetAgentPatrolDesination()
    {
        //checking to make sure we have a patrol point to move to, that the array has not run out
        if (patrolPoints.Length > _nextLocation)
        {
            //if we do have the next position avalible in the array, set the desination to this next point 
            _agent.SetDestination(patrolPoints[_nextLocation].position);

            //adding 1 to the next location so that next time the function is called we are moving to the next point properly 
            _currentDestination = _nextLocation;
            _nextLocation++;
        }
        else
        {
            _nextLocation = 0;
            _currentDestination = -1;
            SetAgentPatrolDesination();
        }
    }

    void SetPlayerSightedDestination()
    {
        _agent.SetDestination(_targetSightedPosition);
    }
}
