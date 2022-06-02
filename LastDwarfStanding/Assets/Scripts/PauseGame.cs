using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{

    public GameObject escape_Button;
    public GameObject pause_UI;
    public GameObject transparentBackground;
    private PlayerNavigationManager _playerNavigationManager;

    private void Awake()
    {
        _playerNavigationManager =FindObjectOfType<PlayerNavigationManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pause_UI.SetActive(false);
        transparentBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeLevel()
    {
        pause_UI.SetActive(false);
        transparentBackground.SetActive(false);
        _playerNavigationManager.isControllerActive = true;

    }

    public void PauseLevel()
    {
        pause_UI.SetActive(true);
        transparentBackground.SetActive(true);
        _playerNavigationManager.isControllerActive = false;



    }

}