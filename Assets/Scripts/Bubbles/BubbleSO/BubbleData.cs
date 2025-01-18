using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "ScriptableObject/BubbleType")]
public class BubbleData : ScriptableObject
{
    public Sprite sprite;
    public float hp;
    public int rewardpoints;

    public GameObject dropItem;

    public GameObject specialItem;
}