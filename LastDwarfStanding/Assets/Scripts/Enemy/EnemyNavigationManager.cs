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
    public bool canEnemyAttack = true;
    public float attackRange;
    
    public float enemySwingDelay;
    private float _swingTimer;

    public GameObject weapon;

    public eEnemyState enemyState;

    private GameObject _target;
    private GameObject _player;
    private GameObject _base;

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
        _swingTimer += Time.deltaTime;
        if (_swingTimer >= enemySwingDelay)
        {
            canEnemyAttack = true;
            weapon.GetComponent<Animator>().SetTrigger("Swing");
            Debug.Log("attacking");
            _swingTimer = 0;

        }
        else
        {
            canEnemyAttack = false;
        }
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
