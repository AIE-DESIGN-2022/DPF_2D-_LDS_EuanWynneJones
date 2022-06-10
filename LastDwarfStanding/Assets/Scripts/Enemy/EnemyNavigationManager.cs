using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum eEnemyState
{
    MoveTowardsBase,
    MoveTowardsTarget,
    AttackTarget,
    StepBack
}




public class EnemyNavigationManager : MonoBehaviour


{
    public bool isEnemyActive = true;

    public float attackRange;
    
    public float enemySwingDelay;
    private float _swingTimer;

    public GameObject weapon;

    public eEnemyState enemyState;

    public GameObject _target;
    private GameObject _player;
    private GameObject _base;
    public GameObject _stepBack;

    private NavMeshAgent _agent;

    private PauseGame _pauseGame;

    public float stoppingRange;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _base = GameObject.FindGameObjectWithTag("Base");


        _pauseGame = FindObjectOfType<PauseGame>();
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

        MovementLogic();

        EnemyNavLogic();
    }

    private void MovementLogic()
    {
        if (enemyState == eEnemyState.AttackTarget) return;

        if (PathisClear())
        {
            //print(name + " path is clear");
            _agent.isStopped = false;
            _agent.destination = _target.transform.position;
        }
        
        else
        {
            print(name + " path is not clear");
            _agent.destination = transform.position;
            _agent.isStopped = true;
        }
    }

    private void EnemyNavLogic()
    {
        if (!PathisClear()) return;

        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        float distanceToBase = Vector3.Distance(transform.position, _base.transform.position); ;
        float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
        float distanceToStepBack = Vector3.Distance(transform.position, _stepBack.transform.position);

        if (distanceToTarget < attackRange && enemyState != eEnemyState.StepBack)
        {
            if (distanceToTarget < attackRange - 0.5f)
            {
                if (!isEnemyActive) return;
                SetEnemyState(eEnemyState.StepBack);
            }
            else
            {
                if (!isEnemyActive) return;
                SetEnemyState(eEnemyState.AttackTarget);
            }
        }
        else if (distanceToPlayer > attackRange)
        {
            if (distanceToPlayer < distanceToBase)
            {
                if (!isEnemyActive) return;
                SetEnemyState(eEnemyState.MoveTowardsTarget);
            }
            else if (distanceToPlayer > distanceToBase)
            {
                if (!isEnemyActive) return;
                SetEnemyState(eEnemyState.MoveTowardsBase);
            }
        }

    }

    private bool PathisClear()
    {
        Vector3 direction = new Vector3(-1, 0 ,0);
        Debug.DrawRay(this.transform.position, direction * stoppingRange, Color.yellow);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, stoppingRange);
        if (hits.Length>0)
        {
            foreach (RaycastHit hit in hits)
            {
                EnemyNavigationManager enemy = hit.transform.gameObject.GetComponent<EnemyNavigationManager>();

                if (enemy != null && enemy != this)
                {
                    return false;
                }
            }
        }
        else
        {
            print(name + "not getting any hits");
        }

        return true;
    }

    private void Attack()
    {
        _swingTimer += Time.deltaTime;
        if (_swingTimer >= enemySwingDelay)
        {
            GetComponentInChildren<EnemyWeapon>().didDamage = false;
            weapon.GetComponent<Animator>().SetTrigger("Swing");
            //Debug.Log("attacking");
            _swingTimer = 0;
        }

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

            case eEnemyState.StepBack:
                
                float stepBackDistance = Vector3.Distance(transform.position, _stepBack.transform.position);
                _stepBack.transform.position = transform.position + new Vector3(1.5f, 0, 0);
                
                if (stepBackDistance > 0.1f)
                {
                    _agent.isStopped = false;
                    _target = _stepBack;
                    _agent.destination = _target.transform.position;
                }
                else
                {
                    //enemyState = eEnemyState.AttackTarget;
                    _target = _player;
                }
                break;
        }

        if (enemyState != eEnemyState.AttackTarget)
        {
            _agent.destination = _target.transform.position;
        }
    }
}
