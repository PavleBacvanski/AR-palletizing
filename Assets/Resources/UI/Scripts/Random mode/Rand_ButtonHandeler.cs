using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Resources.Scripts.RandomMode;
using System.Text;

public class Rand_ButtonHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    private MultiTargetDisabler mtd;
    private UI_Main ui;
    radMode_RenderBoxAtPosition redModeRende;
    bool firstTimeLucky = true;
    Box currentBox;

    void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui = GameObject.FindObjectOfType<UI_Main>();
        redModeRende = GameObject.FindObjectOfType<radMode_RenderBoxAtPosition>();
       

    }

    public void nextScan()
    {
        if (this.firstTimeLucky)
        {
            this.startPacking();
            this.firstTimeLucky = false;
            return;
        }
        mtd.destroyCollider(currentBox.Name);
      //  mtd.boxPlaced(ui.name);
        mtd.enableMultiTargets();

        //SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
        //soundManager.source.PlayOneShot(soundManager.box);


        redModeRende.boxPlaced(this.currentBox.Name);
        GameObject objText = GameObject.FindGameObjectWithTag("box_num").gameObject;
        objText.GetComponent<Text>().text = "No. "+this.redModeRende.numOfBoxexPlaced().ToString();
        this.startPacking();

    }
    public void startPacking()
    {
        Box nextBox = redModeRende.NextBox();
        if (nextBox == null)
        {
            ui.setUIALL(UIStatus.Grey, "All Boxex placed", "complete", false, "DONE");
            return;
        }
        string message = "Next box to be placed is: " + nextBox.Name;
        ui.setUIALL(UIStatus.Grey, message, nextBox.Name, false, "");
        currentBox = nextBox;
    }

}

