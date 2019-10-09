using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

using System.Xml;
public class Test_Xml
{
    XmlNodeList levelsList;
    [Test]
    public void TestXMLINPUT()
    {
        BoxTest(new Vector3(0.15f, 0.05f, 0.23f), getSizeBoxName("k1"));
        BoxTest(new Vector3(0.11f, 0.04f, 0.16f), getSizeBoxName("k2"));
        BoxTest(new Vector3(0.1f, 0.1f, 0.1f), getSizeBoxName("k3"));
        BoxTest(new Vector3(0.08f, 0.07f, 0.12f), getSizeBoxName("k4"));
        BoxTest(new Vector3(0.12f, 0.1f, 0.12f), getSizeBoxName("k5"));
        BoxTest(new Vector3(0.08f, 0.08f, 0.14f), getSizeBoxName("k6"));
        BoxTest(new Vector3(0.15f, 0.15f, 0.15f), getSizeBoxName("k7"));
    }

    private Vector3 getSizeBoxName(string boxName)
    {
        XmlDocument _document = new XmlDocument();
        _document.Load("Assets/Resources/edit.xml");
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
        vec.x = (float)System.Math.Round(vec.x, 2);
        vec.y = (float)System.Math.Round(vec.y, 2);
        vec.z = (float)System.Math.Round(vec.z, 2);
        return vec;
    }

    public void BoxTest(Vector3 actSize, Vector3 Size)
    {
        Assert.AreEqual(actSize, Size);
    }



}