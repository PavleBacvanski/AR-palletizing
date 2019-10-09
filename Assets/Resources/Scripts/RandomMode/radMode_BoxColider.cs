using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for making colieder around a box
/// </summary>
public class radMode_BoxColider : MonoBehaviour
{
    
    [SerializeField]
    private GameObject colliderPrefab;  //coliader prefab that need to be instantiate
    public GameObject colider;      //reference to coliader around a box

    private XML_Reader xmlReader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.colider!=null)
            this.colider.transform.position = this.transform.position;
    }
    //function for creating a coliader around a box
    public void makeBlueBox(string boxName)
    {
        if (this.colider == null)
        {
            xmlReader = GameObject.FindObjectOfType<XML_Reader>();
            Vector3 size = xmlReader.getSizeByName(this.name);
            this.colider = Instantiate(colliderPrefab, this.transform);
            this.colider.transform.localScale = size * .8f;
        }
       
    }
   /* public void destroyBlueBox()
    {
        DestroyImmediate(this.colider);
        
    }*/
}
