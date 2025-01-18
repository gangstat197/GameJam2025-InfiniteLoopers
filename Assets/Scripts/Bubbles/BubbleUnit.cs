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

    protected float hp; // hp thực tế 
    protected float hpMax;

    protected float damage;
    protected float rewardpoints;

    public BubbleData bubbleData;

    protected Vector3 start;
    protected Vector3 end;
    protected bool isMoving = false;


    protected void SetValues(Sprite sprite, Animator IdleAnimator, Animator HitAnimator, Animator DeadAnimator, float hp, float damage, float rewardpoints){
        this.sprite = sprite;
        this.IdleAnimator = IdleAnimator;
        this.HitAnimator = HitAnimator;
        this.DeadAnimator = DeadAnimator;

        // increase by wave 
        this.hp = hp; // this.hp = hp + %WaveManager.Instance.wave
        this.hpMax = hp; // don't change

        this.damage = damage; // this.damage = damage + %WaveManager.Instance.wave
        this.rewardpoints = rewardpoints; // this.rewardpoints = rewardpoints + %WaveManager.Instance.wave
    }

    // load data
    public virtual void Start(){

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
    public virtual void Spawn(Vector3 start, Vector3 end, float speed){
        
        transform.position = start;
        
        this.start = start;
        this.end = end;

        isMoving = true;

    }

    // Make calculate, animation when bubbles be hitted 
    protected virtual void Hitted(){
        // Waiting for Luu's pointer finish to link

        //renderer.GetHurt(hp, maxhp);

    }

    // For moving only
    protected virtual void Moving(Vector3 start, Vector3 end, float speed){

        Vector3 direction = (end - start).normalized;
        

        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, end) < 0.1f){
                
            Destroy(gameObject);
                
        }

    }

    public virtual void Update(){
        if(isMoving){
            Moving(start, end, 2f);
        }

    }


    // Chance get item but 100% have rewardpoints 
    public virtual Item Dead(){
        return null;
    }
}
