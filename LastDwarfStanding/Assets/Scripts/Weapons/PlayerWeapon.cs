using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float damage;
    public float lifeTime;
    private PlayerHealthManager owner;
    private EnemyHealthManager enemyOwner;




    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Weapon")
        {
            if (other.gameObject.tag == "EnemyMelee")
            {
                other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);

            }
        }
    }
}
