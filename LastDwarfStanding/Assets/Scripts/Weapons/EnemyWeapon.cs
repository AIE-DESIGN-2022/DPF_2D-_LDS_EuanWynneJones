using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage;
    public GameObject Weapon;




    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
            if (other.gameObject.tag != "EnemyMelee" && other.gameObject.tag != "EnemyWeapon")
            {
                if (other.gameObject.tag == "Player")
                {
                    
                    Debug.Log("Damageing Player");
                Weapon.GetComponent<Animator>().SetTrigger("Swing");
                other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
                    
                }
            }
    }
}

