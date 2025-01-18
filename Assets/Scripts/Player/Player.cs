using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public PlayerData playerData;

    public float playerHealth;
    public float playerArmor;
    public float playerAttackRange;
    public float playerDamage;
    public float playerCritRate;

    public PlayerAttack playerAttackComponent;

    private void SetValue(PlayerData playerData) {
        playerHealth = playerData.playerHealth;
        playerArmor = playerData.playerArmor;
        playerAttackRange = playerData.playerAttackRange;
        playerDamage = playerData.playerArmor;
        playerCritRate = playerData.playerCritRate;
    }

    void Awake() {
        instance = this;
    }

    void Start()
    {
        SetValue(playerData);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            playerAttackComponent.LightAttack(playerDamage, playerCritRate);
        }
    }


    void PlayerHitted(float counterDamage) {
        
    }

    void Dead() {

    }

    void Special() {

    }
}
