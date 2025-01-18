using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask attackableLayer;
    public SpriteRenderer rangeIndicator;
    private float attackRange;
    public void Update() {
        attackRange = Player.instance.playerAttackRange;
    }

    float CalculateDamage(float playerDamage, float playerCritRate) {
        float critRate = Mathf.Clamp01(playerCritRate);

        bool isCritical = Random.value < critRate;

        float finalDamage = isCritical ? playerDamage : playerDamage * 2;
        return finalDamage;
    }

    public void LightAttack(float playerDamage, float playerCritRate) {
        UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Collider2D[] hitBubbles = Physics2D.OverlapBoxAll(mousePosition, new UnityEngine.Vector2(attackRange, attackRange), 0, attackableLayer);
        
        foreach (Collider2D bubble in hitBubbles) {
            BubbleUnit bubbleUnit = bubble.GetComponent<BubbleUnit>();

            bubbleUnit.Hitted(CalculateDamage(playerDamage, playerCritRate));
        }        
    }

    private void OnDrawGizmosSelected() {
        if (Camera.main == null) return;

        UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(mousePosition, new UnityEngine.Vector3(attackRange, attackRange, 0));
    }
}
