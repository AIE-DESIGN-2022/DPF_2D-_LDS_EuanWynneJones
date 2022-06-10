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

    public bool LootDropped = false;

    public GameObject loot;
    public Transform spawnPosition;

    public EnemySoundManager enemySoundManager;


    // Start is called before the first frame update
    void Start()
    {
        enemySoundManager = GetComponent<EnemySoundManager>();
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
            LootDropped = false;
            OnDeath();
        }
    }
    private void OnDeath()
    {

        gameObject.tag = "DeadEnemy";
        if (!LootDropped)
        {
        SpawnLoot();
        enemySoundManager.PlayAudioClip("EnemyDeath");

        }
        Destroy(gameObject,0.7f);
        LootDropped = false;
    }

    private void SpawnLoot()
    {
        Debug.Log("Dropping Coin");
        GameObject LootClone = Instantiate(loot, spawnPosition.position, spawnPosition.rotation);
        LootDropped = true;

    }
}
