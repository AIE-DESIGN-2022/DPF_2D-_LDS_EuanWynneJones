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

    private void Update()
    {

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
            if (other.gameObject.tag == "Base" && !didDamage)
            {
                didDamage = true;
                other.gameObject.GetComponent<BaseHealthManager>().TakeDamage(damage);
                enemySoundManager.PlayAudioClip("TakeDamage");
            }
        }

        if (other.gameObject.tag != "EnemySiege" && other.gameObject.tag != "EnemySiegeWeapon" && other.gameObject.tag != "EnemyMelee" && other.gameObject.tag != "EnemyWeapon")
        {

            //Debug.Log("EnemySiege IS Damageing" + name);
            if (other.gameObject.tag == "Player" && !didDamage)
            {
                didDamage = true;
                other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
                enemySoundManager.PlayAudioClip("HammerCrush");
                //Debug.Log("Played Sound" + enemySoundManager.name);

            }
            if (other.gameObject.tag == "Base" && !didDamage)
            {
                didDamage = true;
                other.gameObject.GetComponent<BaseHealthManager>().TakeDamage(damage);
                enemySoundManager.PlayAudioClip("HammerCrush");
            }

        }



        if (other.gameObject.tag != "EnemyRanger" && other.gameObject.tag != "Arrow")
        {
            if (other.gameObject.tag == "Player" && !didDamage)
            {
                didDamage = true;
                //Debug.Log("Damageing Player");
                other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
                enemySoundManager.PlayAudioClip("ArrowHitFlesh");

            }

            if (other.gameObject.tag == "Base" && !didDamage)
            {
                didDamage = true;
                other.gameObject.GetComponent<BaseHealthManager>().TakeDamage(damage);
                enemySoundManager.PlayAudioClip("ArrowHitShield");
            }






        }
    }
}






    





