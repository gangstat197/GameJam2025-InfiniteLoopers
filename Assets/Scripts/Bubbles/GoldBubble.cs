using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoldBubble : BubbleUnit
{

    protected override void Moving(Vector3 start, Vector3 end, float speed){
        
        base.Moving(start, end, speed * 3);

    }


    public override void Dead(){

        
        GameObject lootItem = Instantiate(bubbleData.specialItem, transform.position, Quaternion.identity);

        float dropForce = 30f;
        Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        lootItem.GetComponent<Rigidbody2D>().AddForce(dropForce * dropDirection, ForceMode2D.Impulse);

        Transform firstChild = transform.GetChild(0);
        BubbleRenderer renderer = firstChild.GetComponent<BubbleRenderer>();
        renderer.animator.Play("Death1");

        audioManager.GetComponent<AudioManager>().Play("Bubble pop 2");

    }




}