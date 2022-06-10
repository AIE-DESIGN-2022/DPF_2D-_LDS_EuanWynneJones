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

    public GameObject Loot;
    public Transform spawnPosition;
  

    // Start is called before the first frame update
    void Start()
    {

        enemyHealth = enemyMaxHealth;
        _parent = enemyHealthBar.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        _parent = enemyHealthBar.transform.parent;
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
        SpawnLoot();

        Destroy(gameObject);
    }

    private void SpawnLoot()
    {
        Debug.Log("Dropping Coin");
       GameObject LootClone = Instantiate(Loot, spawnPosition.position, spawnPosition.rotation);
    }
}
