using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ColorType colorType;
    public int scoreValue = 0;

    public enum ColorType
    {
        BlackBasketball,
        RedWhiteBlueBasketball,
        OrangeBasketball
    
    }

}
