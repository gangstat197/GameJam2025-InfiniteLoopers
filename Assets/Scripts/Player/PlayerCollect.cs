using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{   
    public float attractSpeed = 5f; // Speed

    private BoxCollider2D collectCollider;
    private void Start() {
        collectCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        collectCollider.size = new Vector2(Player.instance.playerAttackRange * 8f, Player.instance.playerAttackRange * 8f);
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Collectable")) {   
            Debug.Log("Collecting!");
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.transform.position += direction * attractSpeed * Time.deltaTime;

            // If item meets 
            if (Vector3.Distance(transform.position, other.transform.position) < 0.1f) {
                ItemUnit itemUnit = other.gameObject.GetComponent<ItemUnit>();
                if (itemUnit != null) GameManager.instance.AddScore(itemUnit.itemIndex, 1);
                Destroy(other.gameObject);
            }
        }
    }

}
