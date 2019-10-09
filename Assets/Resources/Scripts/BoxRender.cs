using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRender : MonoBehaviour
{

    [SerializeField]
    private GameObject boxPrefab;
    private Dictionary<string,GameObject> dictBox;
    private UI_Main uiMain;
    private MultiTargetDisabler mtd;
    private void UI_Control(string name)
    {
        uiMain.setUiStatusSprite(name);
        uiMain.setUiStatusText("Box is detected!");
        uiMain.setUiStatusButtonText("Place box");
    }

    private void WrongBox(string name)
    {
        uiMain.setUIALL(UIStatus.Red, "Please scan right box!", "", false, "Scan box");
    }

    public void RenderBox(string name, Vector3 pos, Vector3 size)
    {
        if (!dictBox.ContainsKey(name))
        {

            GameObject b = Instantiate(boxPrefab, this.transform.GetChild(0).transform);
            b.transform.localPosition = pos;
            b.transform.localScale = size;
            b.transform.rotation = transform.rotation;
            dictBox.Add(name, b);
            // Veza sa UI
            UI_Control(name);
            SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
            soundManager.source.Play(0);
            mtd.disableMultiTargets(name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        uiMain = GameObject.FindObjectOfType<UI_Main>();
        dictBox = new Dictionary<string, GameObject>();
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
