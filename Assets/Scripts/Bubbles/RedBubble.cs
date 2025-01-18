using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedBubble : BubbleUnit
{
    public override void Dead(){
        float randomValue = Random.Range(0f, 100f);

        if(randomValue - 10f <= 0){
            
            GameObject lootItem = Instantiate(bubbleData.dropItem, transform.position, Quaternion.identity);

            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootItem.GetComponent<Rigidbody2D>().AddForce(dropForce * dropDirection, ForceMode2D.Impulse);
        }

        this.Explode();

        Destroy(gameObject);

    }

    private void Explode(){
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);

        foreach (Collider2D x in hitColliders){

            if (x != GetComponent<Collider2D>()){
                BubbleUnit bU = x.GetComponent<BubbleUnit>();

                if(bU != null){
                    bU.Hitted(10f);
                }
            }
            
            
        }

    }

}