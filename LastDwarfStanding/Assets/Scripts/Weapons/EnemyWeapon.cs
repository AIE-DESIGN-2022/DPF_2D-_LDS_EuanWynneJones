using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage;





    public void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag != "EnemyMelee" && other.gameObject.tag != "EnemyWeapon")
            {
                if (other.gameObject.tag == "Player")
                {
                    
                    Debug.Log("Damageing Player");
               
                other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
                    
                }
            }
    }





}

