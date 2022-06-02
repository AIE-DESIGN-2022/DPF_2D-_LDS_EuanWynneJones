using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public Transform weaponPosition;
    public GameObject weapon;
    public float swingDelay;
    private PlayerNavigationManager _playerNavigationManager;

    private float _spawnTimer;

    private void Awake()
    {
        _playerNavigationManager = FindObjectOfType<PlayerNavigationManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerNavigationManager.isControllerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerNavigationManager.isControllerActive) return;

        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= swingDelay)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject weaponClone = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
                weaponClone.transform.parent = weaponPosition.transform;
                _spawnTimer = 0;
            }

        }
    }
}
