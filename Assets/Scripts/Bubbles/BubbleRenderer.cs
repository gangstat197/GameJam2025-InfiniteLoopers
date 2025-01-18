using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleRenderer : MonoBehaviour
{
    public bool isTesting;
    private bool isHurt;
    public bool isShrink = false;
    public Animator animator;
    public Transform typeBall;
    private Vector3 initScale;
    public float maxScale = 1.2f;
    private float diff = 0;
    private float currentPercent;
    
    void Start()
    {
        initScale = typeBall.localScale;
        diff = maxScale - initScale.x; 
    }
    void Update(){
        if (isTesting){
            if (Input.GetMouseButtonDown(0)){
                GetHurt(5, 10);
            }
            if (isHurt){
                
            }
        }
    }
    
    public void GetHurt(float hp, float maxhp){
        isHurt = true;
        Vector3 v = new Vector3(1.2f, 1.2f, 1.2f);
        currentPercent = ((maxhp - hp)/maxhp);
        typeBall.localScale = diff*currentPercent*v + initScale;
        animator.Play("Hurt");
        Debug.Log("GetHurt");
    }
    public void ChangeToIdle(){
        animator.Play("Idle");
    }
}
