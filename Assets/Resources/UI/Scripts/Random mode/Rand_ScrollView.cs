using Assets.Resources.Scripts.RandomMode;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Scroll view controler class
/// </summary>
public class Rand_ScrollView : MonoBehaviour
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

    //function for pallet statistic
    public void palletPreview()
    {

        float zapremina = 0;
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("PALLET STAT:");
        this.redModeRende = GameObject.FindObjectOfType<radMode_RenderBoxAtPosition>();
        this.scrollViewText = this.GetComponentInChildren<Text>();
        List<Box> boxesAtPallet = this.redModeRende.getBoxesAtPallet();
        if (boxesAtPallet.Count==0)
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
                msg.Append(box.Size.x);
                msg.Append("m²x ");
                msg.Append(box.Size.z);
                msg.Append("m²");
                float povrsina = box.Size.x * box.Size.z;
                msg.Append("box size: ");
                msg.Append(povrsina);
                msg.AppendLine();
                //msg.Append("################");
                zapremina += povrsina * box.Size.y;
            }
        }
        msg.AppendLine();
        msg.Append("Total volume of pallet: ");
        msg.Append(zapremina);
        msg.Append("m³");
        scrollViewText.text = msg.ToString();
           
        
    }
}
