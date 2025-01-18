using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnit : MonoBehaviour
{
    public CollectableItems itemData;

    public Sprite itemSprite;
    public string itemName;
    public int itemIndex;
    void Awake() {   
        SetValue(itemData);
    }

    void SetValue(CollectableItems data) {
        itemSprite = data.itemSprite ?? itemSprite;
        itemName = data.itemName;
        itemIndex = data.itemIndex;
    }
}
