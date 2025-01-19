using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "New Collectable Item", menuName = "ScriptableObject/Collectable Item")]
public class CollectableItems : ScriptableObject
{
    public int itemIndex;
    public string itemName;
    public Sprite itemSprite;
    public float specialCoolDown;
    public float specialDuration;
    public ColorParameter vignetteColor;
}
