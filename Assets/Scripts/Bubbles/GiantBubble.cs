using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiantBubble : BubbleUnit
{

    public GameObject BubbleUnitPrefab;

    public override void Dead(){


        float randomValue = Random.Range(0f, 100f);

        if(randomValue - 10f <= 0){
            
            GameObject lootItem = Instantiate(bubbleData.dropItem, transform.position, Quaternion.identity);

            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootItem.GetComponent<Rigidbody2D>().AddForce(dropForce * dropDirection, ForceMode2D.Impulse);
        }
        
        for(int i = 0; i < 4; i++){

            var ins = WaveManager.Instance;

            ins.process(ins.bubbles[0], transform.position);

        }

        Destroy(gameObject);

    }

    public override void Update(){
        base.Update();
    }


}