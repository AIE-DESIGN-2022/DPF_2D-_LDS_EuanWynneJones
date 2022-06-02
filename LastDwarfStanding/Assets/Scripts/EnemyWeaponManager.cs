using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    public bool canAttack = true;

    public float damage;
    public float attackTime;

    private GameObject _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*ifpublic IEnumerator Attack()
    {
        canAttack = false;
         (isRangedEnemy)
        {
            GameObject projectileClone = Instantiate(enemyProjectile, spawnPosition.position, spawnPosition.rotation);
        }
        else
        {
            _player.GetComponent<HealthManager>().TakeDamage(damage);
        }
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
        */
}

