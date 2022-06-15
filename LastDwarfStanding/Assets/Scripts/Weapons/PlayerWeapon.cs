using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float damage;
    public bool didDamage;




    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Weapon")
        {
            if (other.gameObject.tag == "EnemyMelee" && !didDamage)
            {
                didDamage = true;
                other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);

            }
        }
    }
}

