using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  
/// </summary>
public class RenderBoxAtPosition : MonoBehaviour
{
    private Dictionary<string, Vector3> paletPosition;
    private List<string> placedBoxes;
    private List<string> boxesAtLevel1;
    private List<string> boxesAtLevel2;
    private XML_Reader xmlReader;
    private BoxRender boxRender;
    private int box;
    private MultiTargetDisabler mtd;
    


    public void RenderBox(string name)
    {
        boxRender = GameObject.FindObjectsOfType<BoxRender>()[0];
        Vector3 size = xmlReader.getSizeByName(name);
        size = size * 1;
        Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);
        Vector3 vek = paletPosition[name];


        if (getMyLevel(name) == 2)
        {
            //proveri da li su sve na prvom nivou postavljene

            foreach (string boxAtLevel1 in boxesAtLevel1)
            {
                if (placedBoxes.Contains(boxAtLevel1) == false)
                {
                    UI_Main ui = GameObject.FindObjectOfType<UI_Main>();
                    ui.setUiStatusText("First finish level 1!");
                    ui.setUiStatusColor(UIStatus.Red);

                    //destroyCollider(ui.name);

                    return;
                }
            }
        }

        boxRender.RenderBox(name, paletPosition[name], size);
        
    }

    /// <summary>
    /// Funkcija inicijalizuje Dictionary, koji mapira naziv kutije na njenu poziciju na paleti
    /// Pozicije na paleti su unapred definisane i rucno izracunate
    /// Kutije ne moraju da budu direktno postavljene na paletu
    /// Broj nivoa: 2
    /// </summary>
    private void initialization2()
    {
        paletPosition.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.025f));
        paletPosition.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        paletPosition.Add("k2", new Vector3(-0.2f, 0.25f, -0.079942f));
        paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));
        //paletPositions.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        //paletPositions.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f)); //Kozel
        //paletPositions.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        //paletPositions.Add("k5", new Vector3(-0.04f, 0.25f, -0.06f));
        //paletPositions.Add("k2", new Vector3(-0.2f, 0.25f, -0.079942f)); //Tuborg
        //paletPositions.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        //paletPositions.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }

    public void addToPlacedBoxList(string name)
    {
        placedBoxes.Add(name);
    }

    public List<string> getBoxesAtLevel(int i)
    {
        List<string> boxesAtLevel = new List<string>();

        if (i == 1)
        {
            foreach (KeyValuePair<string, Vector3> currentPaletPosition in paletPosition)
            {
                Vector3 sizeOfCurrentBox = xmlReader.getSizeByName(currentPaletPosition.Key);
                Vector3 positionOnPalet = currentPaletPosition.Value;

                if (positionOnPalet.z + sizeOfCurrentBox.y / 2 >= 0)
                {
                    boxesAtLevel.Add(currentPaletPosition.Key);
                }

            }

        }
        if (i == 2)
        {
            foreach (KeyValuePair<string, Vector3> currentPaletPosition in paletPosition)
            {
                Vector3 sizeOfCurrentBox = xmlReader.getSizeByName(currentPaletPosition.Key);
                Vector3 positionOnPalet = currentPaletPosition.Value;

                if (positionOnPalet.z + sizeOfCurrentBox.y / 2 < 0)
                {
                    boxesAtLevel.Add(currentPaletPosition.Key);
                }

            }

        }
        return boxesAtLevel;
    }

    /// <summary>
    /// Postavlja zeljenu kombinaciju, koju korisnik zadaje iz User interfacea
    /// </summary>
    /// <param name="i">Redni broj kombinacije</param>
    public void setOption(int i)
    {
        paletPosition = new Dictionary<string, Vector3>();

        if (i == 0)
        {
            initialization1();
        }
        if (i == 1)
        {
            initialization2();

        }

        boxesAtLevel1 = getBoxesAtLevel(1);
        boxesAtLevel2 = getBoxesAtLevel(2);
    }

    /// <summary>
    /// Vraca nivo na kojoj se nalazi kutija
    /// nivo = {1, 2}
    /// </summary>
    /// <param name="boxName"></param>
    /// <returns></returns>
    private int getMyLevel(string boxName)
    {
        if (boxesAtLevel1.Contains(boxName))
        {
            return 1;
        }
        if (boxesAtLevel2.Contains(boxName))
        {
            return 2;
        }
        return -1;
    }

    private void initialization1()
    {
        //paletPosition.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        //paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.025f));
        //paletPosition.Add("k6", new Vector3(-.05f, -.1f, -.0699635f));
        //paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        //paletPosition.Add("k2", new Vector3(-0.04f, 0.075f, -0.02f));
        //paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        //paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

        paletPosition.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.025f));
        paletPosition.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        paletPosition.Add("k2", new Vector3(-0.04f, 0.075f, -0.02f));
        paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

        //paletPosition.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        //paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f));
        //paletPosition.Add("k6", new Vector3(-.05f, -.1f, -.040000f));
        //paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        //paletPosition.Add("k2", new Vector3(-0.04f, 0.075f, -0.02f));
        //paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        //paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }
    // Start is called before the first frame update
    void Start()
    {
        xmlReader = GameObject.FindObjectOfType<XML_Reader>();
        mtd = FindObjectOfType<MultiTargetDisabler>();
        paletPosition = new Dictionary<string, Vector3>();
        placedBoxes = new List<string>();
        setOption(SliderHandler.boxHeightLevel);
       // setOption(0);
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
