using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


public class XML_Reader : MonoBehaviour
{

    [SerializeField]
    private TextAsset xml;

    private XmlDocument _document = new XmlDocument();

    private Dictionary<string, Vector3> dict = new Dictionary<string, Vector3>();

    private Vector3 getSizeBoxName(string boxName)
    {
        Vector3 vec = new Vector3();
        foreach (XmlNode node in _document.DocumentElement.SelectNodes("/QCARConfig/Tracking/ImageTarget"))
        {
            string name = node.Attributes["name"]?.InnerText;
            
            if (name == boxName + ".Front")
            {
                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                vec.x = float.Parse(size[0], System.Globalization.CultureInfo.InvariantCulture);
                vec.z = float.Parse(size[1], System.Globalization.CultureInfo.InvariantCulture);
            }
            if (name == boxName + ".Right")
            {
                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                vec.y = float.Parse(size[0], System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        dict.Add(boxName, vec);
        return vec;
    }

    public Vector3 getSizeByName(string name)
    {
        return dict[name];
    }
    // Awake before start
    void Awake()
    {
        _document.LoadXml(xml.ToString());
        List<string> tempName = new List<string>();
        foreach (XmlNode node in _document.DocumentElement.SelectNodes("/QCARConfig/Tracking/ImageTarget"))
        {
            string name = node.Attributes["name"]?.InnerText.Split('.')[0];
            if (!tempName.Contains(name))
            {
                tempName.Add(name);
                getSizeBoxName(name);
            }
        }

        //foreach (KeyValuePair<string,Vector3> entry in dict)
        //{
        //    Debug.Log(entry.Key);
        //    Debug.Log(entry.Value);
        //}
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
