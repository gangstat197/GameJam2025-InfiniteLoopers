using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask attackableLayer;
    public SpriteRenderer rangeIndicator;

    public Color crossHairColor;
    private float attackRange;

    public void Start() {
        rangeIndicator.sortingOrder = 10;
        rangeIndicator.transform.position = new Vector3(rangeIndicator.transform.position.x, rangeIndicator.transform.position.y, -1);
        rangeIndicator.color = crossHairColor;
    }

    public void Update() {
        attackRange = Player.instance.playerAttackRange;
        SetIndicatorSize(attackRange);
        SetIndicatorPosition();
    }

    public void SetIndicatorPosition() {
        if (rangeIndicator != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);;
            rangeIndicator.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
        }        
    }

    public void SetIndicatorSize(float range) {
        float spriteSize = rangeIndicator.sprite.bounds.size.x;
        float scale = attackRange / spriteSize;
        rangeIndicator.transform.localScale = new Vector3(scale, scale, 1);
    }

    float CalculateDamage(float playerDamage, float playerCritRate) {
        float critRate = Mathf.Clamp01(playerCritRate);

        bool isCritical = Random.value < critRate;

        float finalDamage = isCritical ? playerDamage : playerDamage * 2;
        return finalDamage;
    }

    public void LightAttack(float playerDamage, float playerCritRate) {
        Debug.Log("Light Attack");
        UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Collider2D[] hitBubbles = Physics2D.OverlapBoxAll(mousePosition, new UnityEngine.Vector2(attackRange, attackRange), 0, attackableLayer);
        
        foreach (Collider2D bubble in hitBubbles) {
            /* BubbleUnit bubbleUnit = bubble.GetComponent<BubbleUnit>();

            bubbleUnit.Hitted(CalculateDamage(playerDamage, playerCritRate)); */

            Debug.Log($"Hit: {bubble.name}");
        }        
    }

    private void OnDrawGizmosSelected() {
        if (Camera.main == null) return;

        UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(mousePosition, new UnityEngine.Vector3(attackRange, attackRange, 0));
    }
}
