using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIStatus
{
    Green,
    Red,
    Grey
}

public class UI_Main : MonoBehaviour
{
    [SerializeField]
    private GameObject boxLogoList;
    [SerializeField]
    private float transparency;

    private Image imgPlc;
    private Text uiStatus;
    private GameObject uiBtn;


    public string name;

    private Color green = new Color(0, 255, 0);
    private Color red = new Color(255, 0, 0);
    private Color grey = new Color(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        imgPlc = GameObject.FindGameObjectWithTag("Img_plc").GetComponent<Image>();
        uiStatus = GameObject.FindGameObjectWithTag("Status").GetComponent<Text>();
        uiBtn = GameObject.FindGameObjectWithTag("btn_plc");
        green.a = transparency;
        red.a = transparency;
        grey.a = transparency;
    }

    public void setUIALL(UIStatus status, string text, string name, bool btn, string btn_text)
    {
        setUiStatusColor(status);
        setUiStatusText(text);
        setUiStatusSprite(name);
        setUiStatusBtnInteractable(btn);
        setUiStatusButtonText(btn_text);
        this.name = name;
    }

    public void setUiStatusText(string text)
    {
        uiStatus.text = text;
    }

    public void setUiStatusSprite(string name)
    {
        for (int i = 0; i < boxLogoList.transform.childCount; i++)
        {
            GameObject bll = boxLogoList.transform.GetChild(i).gameObject;
            if (bll.name == name)
            {
                imgPlc.sprite = bll.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
        this.name = name;
    }

    public void setUiStatusBtnInteractable(bool bo)
    {
        uiBtn.GetComponent<Button>().interactable = bo;
    }

    public void setUiStatusButtonText(string text)
    {
        uiBtn.transform.GetComponentInChildren<Text>().text = text;
    }

    public void setUiStatusColor(UIStatus status)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "Headline" || transform.GetChild(i).gameObject.name =="Footer" )
            {
                Image img = transform.GetChild(i).gameObject.GetComponent<Image>();
                if (status == UIStatus.Green)
                {
                    img.color = green;
                }
                else if (status == UIStatus.Red)
                {
                    img.color = red;
                }
                else
                {
                    img.color = grey;
                }
            }

        }
    }
}
