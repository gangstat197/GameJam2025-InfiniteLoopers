using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BubbleUnit : MonoBehaviour
{
    
    // Fields
    [SerializeField]
    protected Sprite sprite;

    protected Animator IdleAnimator;
    protected Animator HitAnimator;
    protected Animator DeadAnimator;

    public float hp; // hp thực tế 
    public float hpMax;

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
    public virtual void Hitted(float damage){
        // Waiting for Luu's pointer finish to link
        
        Debug.Log($"damage = {damage}");
        //renderer.GetHurt(hp, maxhp);
        hp -= damage;
        hp = math.max(hp, 0);
        Transform firstChild = transform.GetChild(0);
        BubbleRenderer renderer = firstChild.GetComponent<BubbleRenderer>();

        renderer.GetHurt(hp, hpMax);

        float counterDamage = damage - damage * (hpMax - hp) / hpMax;
        Player.instance.PlayerHitted(counterDamage);

        if (hp <= 0) {
            Dead();
        }
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

        if (hp <= 0){
            Dead();
        }

    }


    // Chance get item but 100% have rewardpoints 
public virtual void Dead()
{
    float randomValue = UnityEngine.Random.Range(0f, 100f);

    if (randomValue - 100f <= 0f)
    {
        GameObject lootItem = Instantiate(bubbleData.dropItem, transform.position, Quaternion.identity);

        float dropForce = 30f;
        Vector2 dropDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

        Rigidbody2D lootRb = lootItem.GetComponent<Rigidbody2D>();
        lootRb.AddForce(dropForce * dropDirection, ForceMode2D.Impulse);

        
        lootRb.drag = 2f; 
    }

    Destroy(gameObject);
}

}
