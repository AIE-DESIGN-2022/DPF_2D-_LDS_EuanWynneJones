using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUITrigger : MonoBehaviour
{

    public UpgradeManager upgradeManager;
    public GameObject upgrade_UI;
    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || (Input.GetKeyDown(KeyCode.E)))
        {
            //Debug.Log("Propt");
            upgradeManager.PauseLevelUpgrade();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           // Debug.Log("Hide Propt");
            upgradeManager.ResumeLevelUpgrade();
        }
    }
}
