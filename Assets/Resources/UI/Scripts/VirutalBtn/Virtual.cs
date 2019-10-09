using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Virtual : MonoBehaviour,IVirtualButtonEventHandler
{
    [SerializeField]
    public GameObject virtualBtn;
    // Start is called before the first frame update
    void Start()
    {
        virtualBtn = GameObject.Find("VirtualButton");
        virtualBtn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void onClick()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Hello Virual pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Hello Virual relesed");
    }
}
