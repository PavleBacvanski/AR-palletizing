using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MultiTargetDisabler : MonoBehaviour
{
    private List<GameObject> listBoxPlaced;
    private string trackedBox;
    // Start is called before the first frame update
    void Start()
    {
        listBoxPlaced = new List<GameObject>();
        disableMultiTargets("");
    }
    
    public void boxUnplaced(string name)
    {
        removePlacedBoxList(name);
    }

    public void boxPlaced(string name)
    {
        addPlacedBoxToList(name);
        enableMultiTargets();
    }

    public void destroyCollider(string name)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            if (obj.name == name)
            {
                for(int j = 0; j < obj.transform.childCount; j++)
                {
                    GameObject ch = obj.transform.GetChild(j).gameObject;
                    if(ch.name != "ChildTargets")
                    {
                        GameObject.Destroy(ch.gameObject);
                    }
                }
            }
        }
        GameObject[] plane_fix = GameObject.FindGameObjectsWithTag("plane_fix");
        Destroy(plane_fix[1].transform.GetChild(0).gameObject);
    }

    public void removePlacedBoxList(string name)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            if (obj.name == name && listBoxPlaced.Contains(obj))
            {
                listBoxPlaced.Remove(obj);
            }
        }
    }

    public void addPlacedBoxToList(string name)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            if (obj.name == name && !listBoxPlaced.Contains(obj))
            {
                listBoxPlaced.Add(obj);
            }
        }
    }

    public void enableMultiTargets()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            if (!listBoxPlaced.Contains(obj))
            {
                MultiTargetBehaviour mtb = obj.GetComponent<MultiTargetBehaviour>();
                mtb.enabled = true;
            }
        }
     }

    public void disableMultiTargets(string name)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            if(obj.name != name)
            {
                MultiTargetBehaviour mtb = obj.GetComponent<MultiTargetBehaviour>();
                mtb.enabled = false;
            }
        }
    }


}
