using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ShieldManager : MonoBehaviour
{

    public Transform shieldPosition;
    public GameObject shield;
    private PlayerNavigationManager _playerNavigationManager;
    private PauseGame _pauseGame;

    private PlayerSoundManager _playerSoundManager;


    private void Awake()
    {
        _playerNavigationManager = FindObjectOfType<PlayerNavigationManager>();
        _playerSoundManager = GetComponent<PlayerSoundManager>();
        _pauseGame = FindObjectOfType<PauseGame>();
    }
    
        
            
    void Start()
    {
     _playerNavigationManager.isControllerActive = true;
    }
        
    

    // Update is called once per frame
    void Update()
    {

        if (!_playerNavigationManager.isControllerActive) return;

        if (Input.GetButtonDown("Fire2") && UnityEngine.EventSystems.EventSystem.current != null &&
            !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            shield.SetActive(true);
            Debug.Log("Right Mouse Pressed Shield UP");
        }
        if (Input.GetButtonUp("Fire2") && UnityEngine.EventSystems.EventSystem.current != null &&
        !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            shield.SetActive(false);
            Debug.Log("Right Mouse let go Shield Down");
        }
    }
}
