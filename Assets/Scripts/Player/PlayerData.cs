using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Setting", menuName = "Setting")]
public class PlayerData : ScriptableObject
{
    float playerHealth;
    float playerArmor;

    float playerAttackRange;
    float playerDamage;
    float playerCritRate;
}
