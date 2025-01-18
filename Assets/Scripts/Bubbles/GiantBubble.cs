using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiantBubble : BubbleUnit
{

    public GameObject BubbleUnitPrefab;

    public override void Dead(){
        float randomValue = UnityEngine.Random.Range(0f, 100f);
        for(int i = 0; i < rewardpoints; i++){
        if (randomValue - 100f <= 0f)
                {
                    GameObject lootItem = Instantiate(bubbleData.dropItem, transform.position, Quaternion.identity);

                    float dropForce = 30f;
                    Vector2 dropDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

                    Rigidbody2D lootRb = lootItem.GetComponent<Rigidbody2D>();
                    lootRb.AddForce(dropForce * dropDirection, ForceMode2D.Impulse);

                    
                    lootRb.drag = 2f; 
                }
        }

        randomValue = UnityEngine.Random.Range(0f, 100f);
        if (randomValue - 12f <= 0f) {
            GameObject lootItem = Instantiate(bubbleData.specialItem, transform.position, Quaternion.identity);

            float dropForce = 30f;
            Vector2 dropDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

            Rigidbody2D lootRb = lootItem.GetComponent<Rigidbody2D>();
            lootRb.AddForce(dropForce * dropDirection, ForceMode2D.Impulse);

            
            lootRb.drag = 2f; 
        }
        
        for(int i = 0; i < 4; i++){

            var ins = WaveManager.Instance;

            ins.process(ins.bubbles[0], transform.position);

        }

        Transform firstChild = transform.GetChild(0);
        BubbleRenderer renderer = firstChild.GetComponent<BubbleRenderer>();
        renderer.animator.Play("Death1");
    }

    public override void Update(){
        base.Update();
    }


}