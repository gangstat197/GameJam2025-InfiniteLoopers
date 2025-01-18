using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Setting", menuName = "Setting")]
public class PlayerData : ScriptableObject
{
    public float playerHealth;
    public float playerArmor;

    public float playerAttackRange;
    public float playerDamage;
    public float playerCritRate;
}
