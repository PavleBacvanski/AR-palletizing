using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.RandomMode
{
   public  class Box
    {
        public string Name { get; set; }
        public Vector3 CenterPositio { get; set; }
        public Vector3 Size { get; set; }

        public Box(string name, Vector3 size, Vector3 cPostion)
        {
            this.Name = name;
            this.Size = size;
            this.CenterPositio = cPostion;
        }
    }
}
