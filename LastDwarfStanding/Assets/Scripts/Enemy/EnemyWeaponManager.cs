using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    //public bool canAttack = true;

    public Transform weaponPosition;
    

    public float damage;

    private GameObject _enemy;
    private EnemyNavigationManager _enemyNavigationManager;
    private PauseGame _pauseGame;



    private void Awake()
    {
        _enemyNavigationManager = FindObjectOfType<EnemyNavigationManager>();
  
        _pauseGame = FindObjectOfType<PauseGame>();

    }

    // Start is called before the first frame update
    void Start()
    {

        _enemy = GameObject.FindGameObjectWithTag("EnemyMelee");
    }

    // Update is called once per frame
    void Update()
    {
  

    }

}


