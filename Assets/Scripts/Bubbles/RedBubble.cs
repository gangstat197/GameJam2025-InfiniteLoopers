using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedBubble : BubbleUnit
{
    public override void Dead(){
        base.Dead();

        this.Explode();

    }

    private void Explode(){
        

    }

}