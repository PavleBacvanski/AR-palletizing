using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private MultiTargetDisabler mtd;
    private UI_Main ui;

    void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui = GameObject.FindObjectOfType<UI_Main>();
    }

    public void nextScan()
    {
        RenderBoxAtPosition renderBoxAtPosition = GameObject.FindObjectOfType<RenderBoxAtPosition>();
        renderBoxAtPosition.addToPlacedBoxList(ui.name);

        //radMode_RenderBoxesAtPosition redMode_RenderBoxesAt = GameObject.FindObjectOfType<radMode_RenderBoxesAtPosition>();


        mtd.destroyCollider(ui.name);
        mtd.boxPlaced(ui.name);
        
        ui.setUIALL(UIStatus.Grey, "Scan next box!", "", false, "Scan next");

        SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
        soundManager.source.PlayOneShot(soundManager.box);

        GameObject objText = GameObject.FindGameObjectWithTag("box_num").gameObject;
        int num;
        try
        {
            num = int.Parse((objText.GetComponent<Text>().text.Split(' '))[1]);
        }
        catch (System.Exception)
        {

            num = 0;
        }
        objText.GetComponent<Text>().text = "No. " + ++num;

        mtd.enableMultiTargets();
    }
}
