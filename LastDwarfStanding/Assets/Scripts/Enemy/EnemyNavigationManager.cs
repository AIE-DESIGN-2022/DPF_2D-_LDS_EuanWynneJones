using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum eEnemyState
{
    MoveTowardsBase,
    MoveTowardsTarget,
    AttackTarget
}




public class EnemyNavigationManager : MonoBehaviour


{
    public bool isEnemyActive = true;
    public float distanceReachedThreashold;
    public float playerChaseThreashold;
    public float attackRange;



    public eEnemyState enemyState;
    private Vector3 _targetSightedPosition;

    private GameObject _target;
    private GameObject _player;
    private GameObject _base;


    public Transform[] TargetDirection;
    private NavMeshAgent _agent;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _base = GameObject.FindGameObjectWithTag("Base");
    }

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyState(eEnemyState.MoveTowardsBase);
    }


    // Update is called once per frame
    void Update()
    {
        if (!isEnemyActive) return;

        EnemyNavLogic();

    }

    private void EnemyNavLogic()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        float distanceToBase = Vector3.Distance(transform.position, _base.transform.position); ;
        float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

        

        if (distanceToTarget < attackRange)
        {
            SetEnemyState(eEnemyState.AttackTarget);
        }
        else
        {
            if (distanceToPlayer < distanceToBase)
            {
                SetEnemyState(eEnemyState.MoveTowardsTarget);
            }
            else if (distanceToPlayer > distanceToBase)
            {
                SetEnemyState(eEnemyState.MoveTowardsBase);
            }
        }

    }

    private void Attack()
    {
        Debug.Log("attacking");
    }

    public void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }


    private void SetEnemyState(eEnemyState newState)
    {
        enemyState = newState;

        switch (enemyState)
        {
            case eEnemyState.MoveTowardsBase:
                _agent.isStopped = false;
                _target = _base;
                break;

            case eEnemyState.MoveTowardsTarget:
                _agent.isStopped = false;
                _target = _player;
                break;

            case eEnemyState.AttackTarget:
                _agent.isStopped = true;
                Attack();
                break;
        }

        if (enemyState != eEnemyState.AttackTarget)
        {
            _agent.destination = _target.transform.position;
        }
    }
}
