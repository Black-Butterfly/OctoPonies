using UnityEngine;
using System.Collections;

public partial class PlayerScript
{
    public int getScaleFactor()
    {
       return ((int) (this.transform.localScale.x / 2));
    }
}
