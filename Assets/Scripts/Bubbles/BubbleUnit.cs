using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleUnit : MonoBehaviour
{
    
    // Fields
    [SerializeField]
    protected Sprite sprite;

    protected Animator IdleAnimator;
    protected Animator HitAnimator;
    protected Animator DeadAnimator;

    protected float hp;
    protected float damage;
    protected float rewardpoints;

    void SetValues(Sprite sprite, Animator IdleAnimator, Animator HitAnimator, Animator DeadAnimator, float hp, float damage, float rewardpoints){
        this.sprite = sprite;
        this.IdleAnimator = IdleAnimator;
        this.HitAnimator = HitAnimator;
        this.DeadAnimator = DeadAnimator;
        this.hp = hp;
        this.damage = damage;
        this.rewardpoints = rewardpoints;
    }

    // load data
    public void Start(){
       BubbleData bubbleData = Resources.Load<BubbleData>("BubbleType/BubbleUnit");

       if(bubbleData != null){
            Debug.Log("Nah i would win");

            // SetValues for each type of Bubble
            SetValues(
                bubbleData.sprite, bubbleData.IdleAnimator, bubbleData.HitAnimator, 
                bubbleData.DeadAnimator, bubbleData.hp, bubbleData.damage, bubbleData.rewardpoints
            );
       }


    }

    // Still not understand 
    protected virtual void Spawn(){


    }

    // Make calculate, animation when bubbles be hitted 
    protected virtual void Hitted(){
        // Waiting for Luu's pointer finish to link




    }

    // For moving only
    protected virtual void Moving(){
        


    }

    // Chance get item but 100% have rewardpoints 
    public virtual Item Dead(){
        return null;
    }








    





}
