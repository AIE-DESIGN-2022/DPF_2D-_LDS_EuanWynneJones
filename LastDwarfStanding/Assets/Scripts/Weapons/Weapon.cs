using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float lifeTime;
    bool canHit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SwingTimer");
        canHit = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SwingTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Weapon")
        {
            if (other.gameObject.tag == "EnemyMelee")
            {
                if (canHit)
                {
                    other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                    canHit=false;
                }
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
