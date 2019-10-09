using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class PlaneDisabler : MonoBehaviour
{
    public void StageOnlyOnce()
    {
        this.gameObject.GetComponent<AnchorInputListenerBehaviour>().gameObject.SetActive(false);
        this.gameObject.GetComponent<PlaneFinderBehaviour>().gameObject.SetActive(false);
        UI_Main ui = GameObject.FindObjectOfType<UI_Main>();
        //ui_main.setUiStatusText("Ground plane setted.");
        //ui_main.setUiStatusButtonText("Scan next");
        //ui_main.setUiStatusBtnInteractable(true);
        if (SceneManager.GetActiveScene().name == "RandomModeSCENA")
        {
            ui.setUIALL(UIStatus.Green, "Scan the boxes u want to place!", "", true, "Finish scaning");
        }
        else
        {
            ui.setUIALL(UIStatus.Green, "Ground plane placed successfuly!", "", false, "Scan box");
        }
        MultiTargetDisabler mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        mtd.enableMultiTargets();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.gameObject.GetComponent<AnchorInputListenerBehaviour>().gameObject.SetActive(false);
            this.gameObject.GetComponent<PlaneFinderBehaviour>().gameObject.SetActive(false);
        }
    }
}
