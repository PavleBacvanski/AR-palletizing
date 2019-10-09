using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Controller : MonoBehaviour
{
    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;

    private MultiTargetDisabler mtd;
    private UI_Main ui;

    private void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui = GameObject.FindObjectOfType<UI_Main>();
    }

    private Vector3[] getCornersOfBoxCollider(GameObject b)
    {
        Vector3[] verts = new Vector3[9];
        verts[0] = b.transform.position + new Vector3(-b.transform.localScale.x, -b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[1] = b.transform.position + new Vector3(-b.transform.localScale.x, -b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[2] = b.transform.position + new Vector3(-b.transform.localScale.x, b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[3] = b.transform.position + new Vector3(-b.transform.localScale.x, b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[4] = b.transform.position + new Vector3(b.transform.localScale.x, -b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[5] = b.transform.position + new Vector3(b.transform.localScale.x, -b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[6] = b.transform.position + new Vector3(b.transform.localScale.x, b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[7] = b.transform.position + new Vector3(b.transform.localScale.x, b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[8] = b.transform.position;
        return verts;
    }

    public void OnTriggerStay(Collider other)
    {
        // IME BOXA
        string name = other.gameObject.transform.parent.name;

        // Krajnje tacke boxa
        Vector3[] verts = getCornersOfBoxCollider(other.gameObject.GetComponent<Collider>().gameObject);
        int numOfVertsContained = 0;
        Bounds bd = GetComponent<Collider>().bounds;
        if (bd.Contains(verts[0]) && bd.Contains(verts[1]) && bd.Contains(verts[4]) && bd.Contains(verts[5]))
        {
            numOfVertsContained += 4;
        }
        if (bd.Contains(verts[2]) && bd.Contains(verts[3]) && bd.Contains(verts[6]) && bd.Contains(verts[7]))
        {
            numOfVertsContained += 4;
        }

        for (int i = 0; i < verts.Length; i++)
        {
            if (bd.Contains(verts[i]))
            {
                numOfVertsContained++;
            }
        }
        Debug.Log(numOfVertsContained);
        if (numOfVertsContained >= 4)
        {
            //OVDE UPADA KOD UKOLIKO JE KUTIJA NA TACNOJ POZICIJI
            GetComponent<MeshRenderer>().material = green;
            ui.setUIALL(UIStatus.Green, "Box is on the place!", name, true, "Next");
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;
            ui.setUIALL(UIStatus.Red, "Box is NOT on the place!", name, false, "Scan again");
        }
    }
}
