using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randMode_btnPaletPreview : MonoBehaviour
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
    public void btnScrollPreview()
    {
        scrollViewScript = GameObject.FindObjectOfType<Rand_ScrollView>();
        if (this.scrollViewScript != null)
            this.scrollViewScript.palletPreview();
    }
}
