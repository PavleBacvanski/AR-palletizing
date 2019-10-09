using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBox : MonoBehaviour
{
    private List<GameObject> listaMultiTargeta;
    [SerializeField]
    private GameObject colliderPrefab;
    private XML_Reader xmlReader;
    private List<GameObject> listaCollidera;
    // Start is called before the first frame update
    void Start()
    {
        listaCollidera = new List<GameObject>();
        xmlReader = GameObject.FindObjectOfType<XML_Reader>();
        listaMultiTargeta = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject b = this.transform.GetChild(i).gameObject;
            Vector3 size = xmlReader.getSizeByName(b.name);
            GameObject col = Instantiate(colliderPrefab, b.transform);
            col.transform.localScale = size * 0.85f;
            listaCollidera.Add(col);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
