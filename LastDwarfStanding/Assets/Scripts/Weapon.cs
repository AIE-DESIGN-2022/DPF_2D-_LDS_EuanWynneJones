using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SwingTimer");
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

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Weapon")
        {
            if (other.gameObject.tag == "EnemyMelee")
            {
                //other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
