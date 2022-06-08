using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage;
    public float lifeTime;
    bool canHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
 

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
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