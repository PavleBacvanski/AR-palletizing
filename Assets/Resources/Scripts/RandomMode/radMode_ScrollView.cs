using Assets.Resources.Scripts.RandomMode;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class radMode_ScrollView : MonoBehaviour
{
    radMode_RenderBoxAtPosition redModeRende;
    Text scrollViewText;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void palletPreview()
    {

        StringBuilder msg = new StringBuilder();
        msg.AppendLine("PALLET STAT:");
        this.redModeRende = GameObject.FindObjectOfType<radMode_RenderBoxAtPosition>();
        this.scrollViewText = this.GetComponentInChildren<Text>();
        List<Box> boxesAtPallet = this.redModeRende.getBoxesAtPallet();
        if (boxesAtPallet.Count == 0)
        {
            msg.AppendLine("Pallet is empty");
        }
        else
        {
            foreach (Box box in boxesAtPallet)
            {
                // Text tmp = ScrollRect.transform.GetComponent<Text>();
                //Text tmp = ScrollRect.GetComponentInChildren<Text>();
                // msg.AppendLine("################");
                msg.Append("Box name:");
                msg.Append(box.Name);
                msg.Append("box size: ");
                msg.Append(box.Size.ToString());
                msg.AppendLine();
                //msg.Append("################");
            }
        }
        scrollViewText.text = msg.ToString();


    }
}
