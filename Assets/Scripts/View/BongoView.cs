using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BongoView : ScriptableObject
{
    public Color ActiveColor;
    public Color UnactiveColor;
    public Sprite CurrentSprite;
    public int SpawnPercentage;
    public int BongoMaxValue;
}