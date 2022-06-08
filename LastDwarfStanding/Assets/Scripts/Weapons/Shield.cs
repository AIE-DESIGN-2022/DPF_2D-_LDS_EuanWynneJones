using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{



    public float damageBlocked;
    bool canBlock;

    void Start()
    {
        canBlock = true;
    }

    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with enemy");
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Shield")
        {
            if (other.gameObject.tag == "EnemyMelee")
            {
                if (canBlock)
                {

                    Debug.Log("Player blocks enemy damage");
                   // other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                   //  canBlock = false;
                }
            }
        }

    }
}
