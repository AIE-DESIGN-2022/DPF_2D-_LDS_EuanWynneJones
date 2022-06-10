using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage;
    public bool didDamage;
    public EnemySoundManager enemySoundManager;

    private void Start()
    {
        enemySoundManager = GetComponentInParent<EnemySoundManager>();
    }


    public void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag != "EnemyMelee" && other.gameObject.tag != "EnemyWeapon")
            {
                if (other.gameObject.tag == "Player" && !didDamage)
                {
                    didDamage = true;
                //Debug.Log("Damageing Player");
                other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
                enemySoundManager.PlayAudioClip("TakeDamage");
                    
                }
            }
    }





}

