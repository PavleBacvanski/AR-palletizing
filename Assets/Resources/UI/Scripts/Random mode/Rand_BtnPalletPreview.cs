using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script for pallet preview button that needs to show statistic of the pallet 
/// </summary>
public class Rand_BtnPalletPreview : MonoBehaviour
{
    Rand_ScrollView scrollViewScript;// = GameObject.FindObjectOfType<Rand_ScrollView>();

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function fthat calls sroll preview for showing statistic of the pallet
    public void btnScrollPreview()
    {
        scrollViewScript = GameObject.FindObjectOfType<Rand_ScrollView>();
        if (this.scrollViewScript !=null)
            this.scrollViewScript.palletPreview();
    }
}
