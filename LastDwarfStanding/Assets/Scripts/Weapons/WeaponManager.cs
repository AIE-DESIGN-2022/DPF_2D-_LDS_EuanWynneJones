using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class WeaponManager : MonoBehaviour
{

    public Transform weaponPosition;
    public GameObject weapon;
    public float swingDelay;
    private PlayerNavigationManager _playerNavigationManager;
    private PauseGame _pauseGame;

    private PlayerSoundManager _playerSoundManager;

    private float _spawnTimer;

    private void Awake()
    {
        _playerNavigationManager = FindObjectOfType<PlayerNavigationManager>();
        _playerSoundManager = GetComponent<PlayerSoundManager>();
        _pauseGame = FindObjectOfType<PauseGame>();

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
            if (Input.GetButtonDown("Fire1") && UnityEngine.EventSystems.EventSystem.current != null &&
            !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {


                weapon.GetComponent<Animator>().SetTrigger("Swing");
                Debug.Log("Left Mouse Pressed weapon Swing");
                _spawnTimer = 0;
               // _playerSoundManager.PlayAudioClip("Swoosh");


            }

        }
    }

}
