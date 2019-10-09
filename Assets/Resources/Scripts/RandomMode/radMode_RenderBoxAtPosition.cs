using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.RandomMode;


/// <summary>
/// Script added to ARCamera. 
/// </summary>
public class radMode_RenderBoxAtPosition : MonoBehaviour
{
    #region Variables
    private Dictionary<string, Vector3> paletPosition;
    private XML_Reader xmlReader;
    private BoxRender boxRender;
    private int boxPointer;     //pointing at next box that need to be placed

    List<Box> boxesAtPallet;    //list of current boxes at pallet
    List<Box> scanBoxes;        //list of scan boxes
    List<string> boxesAtLevel1;
    List<string> boxesAtLevel2;
    SliderHandeler _slider;     // 
    #endregion
    //function for puting a new placed box at list boxesAtPallet
    public void boxPlaced(string boxName ){
        Box box = this.scanBoxes.Find(el => el.Name == boxName);
        this.boxesAtPallet.Add(box);
    }
    public int numOfBoxexPlaced()
    {
        return this.boxesAtPallet.Count;
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
    //Function for geting next box that need to be placed at pallet
    public Box NextBox()    //prvo vrati sve sa prvog nivoa
    {
        if (boxPointer < this.scanBoxes.Count)
        {

            if (getMyLevel(this.scanBoxes[this.boxPointer].Name) == 2)
            {
                //proveri da li su sve na prvom nivou postavljene

                foreach (string boxAtLevel1 in boxesAtLevel1)
                {
                    Box myBox = boxesAtPallet.Find(el=>el.Name.Equals(boxAtLevel1));
                    if (myBox == null)
                    {
                        UI_Main ui = GameObject.FindObjectOfType<UI_Main>();
                        ui.setUiStatusText("First finish level 1!");
                        ui.setUiStatusColor(UIStatus.Red);
                        this.scanBoxes.Add(myBox);
                        this.boxPointer++;
                        break;
                    }
                }
            }
            if (boxPointer < this.scanBoxes.Count)
            {
                RenderBox(this.scanBoxes[boxPointer].Name);

                radMode_BoxColider[] prefabList = GameObject.FindObjectsOfType<radMode_BoxColider>();
                foreach (var item in prefabList)
                {
                    if (item.name == this.scanBoxes[boxPointer].Name)
                    {
                        item.makeBlueBox(this.scanBoxes[boxPointer].Name);
                        break;
                    }
                }
                return this.scanBoxes[boxPointer++];

            }
           
        }
        return null;

    }
    //function for retutning list of current box at the pallet
    public List<Box> getBoxesAtPallet()
    {
        return this.boxesAtPallet;
    }
    public void BoxScaned(string boxName)
    {
        Vector3 size = xmlReader.getSizeByName(boxName);
        Vector3 position = this.paletPosition[boxName];
        Box tmp = this.scanBoxes.Find(el => el.Name == boxName);
        if (tmp == null)
        {
            this.scanBoxes.Add(new Box(boxName, size, position));
            SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
            soundManager.source.Play(0);
            UI_Main ui = GameObject.FindObjectOfType<UI_Main>();
           // ui.setUiStatusSprite(boxName);
            ui.setUIALL(UIStatus.Grey, "Number of boxes scaned: " + this.scanBoxes.Count, boxName, true, "Finish scaning");

        }
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
            foreach (KeyValuePair<string, Vector3> paletPosition in paletPosition)
            {
                Vector3 sizeOfCurrentBox = xmlReader.getSizeByName(paletPosition.Key);
                Vector3 positionOnPalet = paletPosition.Value;

                if (positionOnPalet.z + sizeOfCurrentBox.y / 2 < 0)
                {
                    boxesAtLevel.Add(paletPosition.Key);
                }

            }

        }
        return boxesAtLevel;
    }
    public void RenderBox(string name)
    {
        //  this.BoxScaned(name);
        boxRender = GameObject.FindObjectsOfType<BoxRender>()[0];
        Vector3 size = xmlReader.getSizeByName(name);
        size = size * 1;
        Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);
        Vector3 vek = paletPosition[name];
        boxRender.RenderBox(name, paletPosition[name], size);

    }
    #region initialization
    /// <summary>
    /// Funkcija inicijalizuje Dictionary, koji mapira naziv kutije na njenu poziciju na paleti
    /// Pozicije na paleti su unapred definisane i rucno izracunate
    /// Sve kutije su direktno postavljene na paletu(u direktnom kontaktu sa njom) 
    /// Broj nivoa: 1
    /// </summary>
    private void initialization1()
    {
        paletPosition.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.025f));
        paletPosition.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        paletPosition.Add("k2", new Vector3(-0.04f, 0.075f, -0.02f));
        paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

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
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //  boxRender = GameObject.FindObjectsOfType<BoxRender>()[1];

        //paletPosition = new Dictionary<string, Vector3>();
        xmlReader = GameObject.FindObjectOfType<XML_Reader>();
        //int option = 1;
        setOption(SliderHandler.boxHeightLevel);

       

        this.scanBoxes = new List<Box>();
        this.boxesAtPallet = new List<Box>();
        this.boxPointer = 0;

       

    }
    // Update is called once per frame
    void Update()
    {

    }
}
