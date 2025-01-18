using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "ScriptableObject/BubbleType")]
public class BubbleData : ScriptableObject
{
    public Sprite sprite;

    public Animator IdleAnimator;
    public Animator HitAnimator;
    public Animator DeadAnimator;

    public float hp;
    public float damage;
    public float rewardpoints;
}