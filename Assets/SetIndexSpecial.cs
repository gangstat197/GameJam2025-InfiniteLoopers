using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetIndexSpecial : MonoBehaviour
{
    public void SetIndexSpecialMethpd(int index) {
        if (GameManager.instance.points[index] >= 5) Player.instance.playerAttackComponent.SetIndexSkill(index);
    }
}
