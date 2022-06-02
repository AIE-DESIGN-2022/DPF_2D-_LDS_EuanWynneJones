using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthManager : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;
    public Image enemyHealthBar;
    private Transform _parent;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
       // _parent = enemyHealthBar.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //_parent.transform.LookAt(new Vector3(Camera.main.transform.position.x, _parent.transform.position.y, Camera.main.transform.position.z));
    }
    public void TakeDamage(float damageToTake)
    {
        enemyHealth -= damageToTake;
        enemyHealthBar.fillAmount = enemyHealth / enemyMaxHealth;

        if (enemyHealth <= 0)
        {
            OnDeath();
        }
    }
    private void OnDeath()
    {

        Destroy(gameObject);
    }

}
