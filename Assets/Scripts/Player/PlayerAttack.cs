using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask attackableLayer;
    public SpriteRenderer rangeIndicator;

    public Color crossHairColor;
    public SpriteRenderer delayBar;
    private UnityEngine.Vector3 delayBarFirstScale;

    private float lastTimeShoot;

    private float attackRange;


    private float lastUntiTime;
    public List<GameObject> collectableItems;
    ItemUnit item;

    public void Start() {
        rangeIndicator.sortingOrder = 10;
        rangeIndicator.transform.position = new UnityEngine.Vector3(rangeIndicator.transform.position.x, rangeIndicator.transform.position.y, -1);
        rangeIndicator.color = crossHairColor;
        lastTimeShoot = -10;

        delayBarFirstScale = delayBar.transform.localScale;
    }

    public void Update() {
        attackRange = Player.instance.playerAttackRange;
        SetIndicatorSize(attackRange);
        SetIndicatorPosition();

        UpdateDelayBar();
    }

    private void UpdateDelayBar() {
        if (Time.time - lastTimeShoot > Player.instance.playerSpeed) {
            delayBar.transform.localScale = new UnityEngine.Vector3(0, 0, 0);
        } else {
            float ratio = (Time.time - lastTimeShoot) / Player.instance.playerSpeed;
            delayBar.transform.localScale = new UnityEngine.Vector3(ratio * delayBarFirstScale.x, delayBarFirstScale.y, 1);
        }
    }

    public void SetIndicatorPosition() {
        if (rangeIndicator != null)
        {
            UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);;
            rangeIndicator.transform.position = new UnityEngine.Vector3(mousePosition.x, mousePosition.y, -1);
        }        
    }

    public void SetIndicatorSize(float range) {
        float spriteSize = rangeIndicator.sprite.bounds.size.x;
        float scale = attackRange / spriteSize;
        rangeIndicator.transform.localScale = new UnityEngine.Vector3(scale, scale, 1);
    }

    float CalculateDamage(float playerDamage, float playerCritRate) {
        float critRate = Mathf.Clamp01(playerCritRate);

        bool isCritical = Random.value < critRate;

        float finalDamage = isCritical ? playerDamage : playerDamage * 2;
        return finalDamage;
    }

    public void LightAttack(float playerDamage, float playerCritRate) {
        if (Time.time - lastTimeShoot < Player.instance.playerSpeed) return; 
        lastTimeShoot = Time.time;
        Debug.Log("Light Attack");
        UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        Collider2D[] hitBubbles = Physics2D.OverlapBoxAll(mousePosition, new UnityEngine.Vector2(attackRange, attackRange), 0, attackableLayer);
        
        foreach (Collider2D bubble in hitBubbles) {
            BubbleUnit bubbleUnit = bubble.GetComponent<BubbleUnit>();

            bubbleUnit.Hitted(CalculateDamage(playerDamage, playerCritRate));
            Debug.Log($"Hit {bubble.name}");
            Debug.Log($"First Damage {playerDamage}");
        }  

        if (rangeIndicator != null)
        {
            StartCoroutine(AnimateRangeIndicator(rangeIndicator.transform.localScale));
        }      
    }

    private IEnumerator AnimateRangeIndicator(UnityEngine.Vector3 initialScale)
    {
        float elapsedTime = 0f;
        float animationDuration = Player.instance.playerSpeed;
        UnityEngine.Vector3 expandedScale = initialScale * 1.5f; // Scale lớn hơn 1.5 lần kích thước ban đầu

        // Phần animation giật to
        while (elapsedTime < animationDuration / 10)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / (animationDuration / 10);
            rangeIndicator.transform.localScale = UnityEngine.Vector3.Lerp(initialScale, expandedScale, progress);
            yield return null;
        }

        // Phần animation thu nhỏ lại
        elapsedTime = 0f;
        while (elapsedTime < animationDuration / 10 * 9)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / (animationDuration / 10 * 9);
            rangeIndicator.transform.localScale = UnityEngine.Vector3.Lerp(expandedScale, initialScale, progress);
            yield return null;
        }

        // Đảm bảo kích thước quay lại giá trị ban đầu
        rangeIndicator.transform.localScale = initialScale;
    }

    private void OnDrawGizmosSelected() {
        if (Camera.main == null) return;

        UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(mousePosition, new UnityEngine.Vector3(attackRange, attackRange, 0));
    }


    // PLAYER SPECIAL ATTACK


}
