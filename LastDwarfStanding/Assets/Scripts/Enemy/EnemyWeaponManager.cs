using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    public bool canAttack = true;

    public float damage;
    public float attackTime;
    public Transform weaponPosition;
    public GameObject enemyWeapon;
    public bool isRangedClass;

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

    public IEnumerator Attack()
    {
        canAttack = false;
        if (!isRangedClass)
        {
            canAttack = true;
            GameObject weaponClone = Instantiate(enemyWeapon, weaponPosition.position, weaponPosition.rotation);
            weaponClone.transform.parent = weaponPosition.transform;
            yield return new WaitForSeconds(attackTime);
        }
        /*else
        {
            _player.GetComponent<HealthManager>().TakeDamage(damage);
        }
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
        */

    }
}

