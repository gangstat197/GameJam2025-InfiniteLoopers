using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour
{
    int cost = 20;
    public void Upgrade(int type) {
        if (GameManager.instance.points[0] < cost) return;
        GameManager.instance.points[0] -= cost;
        if (type == 1) {
            Player.instance.playerDamage += 5;
        } else 
        if (type == 2) {
            Player.instance.playerSpeed -= 0.1f;
        } else
        if (type == 3) {
            Player.instance.playerCritRate += 2;
        } else 
        if (type == 4) {
            Player.instance.playerAttackRange += 0.5f;
        } else 
        if (type == 5) {
            Player.instance.playerHealth += 20f;
        } else 
        if (type == 6) {
            Player.instance.playerArmor += 10f;
        }
    }
}
