using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{

    public GameObject Escape_Button;
    public GameObject Scroll_UI;
    private PlayerNavigationManager _playerNavigationManager;

    private void Awake()
    {
        _playerNavigationManager =FindObjectOfType<PlayerNavigationManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Scroll_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeLevel()
    {
        Scroll_UI.SetActive(false);
        _playerNavigationManager.isControllerActive = true;

    }

    public void PauseLevel()
    {
        Scroll_UI.SetActive(true);
        _playerNavigationManager.isControllerActive = false;



    }

}