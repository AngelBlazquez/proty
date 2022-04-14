using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Hat",menuName ="")]
public class Hat : ScriptableObject
{
    public string nameHat;
    public Sprite hat;
    public int price;
}
