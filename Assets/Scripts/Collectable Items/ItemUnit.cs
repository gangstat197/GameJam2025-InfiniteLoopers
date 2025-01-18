using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ItemUnit : MonoBehaviour
{
    public CollectableItems itemData;

    public Sprite itemSprite;
    public string itemName;
    public int itemIndex;
    public float coolDown;
    public ColorParameter vignetteColor;
    void Awake() {   
        SetValue(itemData);
    }

    void SetValue(CollectableItems data) {
        itemSprite = data.itemSprite ?? itemSprite;
        itemName = data.itemName;
        itemIndex = data.itemIndex;
        coolDown = data.specialCoolDown;
        vignetteColor = data.vignetteColor;
    }
}
