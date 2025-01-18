using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
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
    public float playerSpeed;

    public float playerCurrentHealth;
    public TextMeshProUGUI pointCounts;
    public PlayerAttack playerAttackComponent;
    public HealthSystem healthSystem;

    private void SetValue(PlayerData playerData) {
        playerHealth = playerData.playerHealth;
        playerCurrentHealth = playerData.playerHealth;
        playerArmor = playerData.playerArmor;
        playerAttackRange = playerData.playerAttackRange;
        playerDamage = playerData.playerDamage;
        playerCritRate = playerData.playerCritRate;
        playerSpeed = playerData.playerSpeed;
    }

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        SetValue(playerData);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            playerAttackComponent.LightAttack(playerDamage, playerCritRate);
        }

        // playerCurrentHealth -= Time.deltaTime * 0.2f * WaveManager.Instance.wave;
        playerCurrentHealth -= Time.deltaTime;
        if (playerCurrentHealth == 0) {
            Dead();
        }

        healthSystem.hitPoint = playerCurrentHealth;
        pointCounts.text = GameManager.instance.points[0].ToString();
    }


    public void PlayerHitted(float counterDamage) {
        playerCurrentHealth -= counterDamage - playerArmor;
    }

    public void Dead() {
        GameManager.instance.UpdateGameState(GameState.UpdateState);
    }

    public void Special() {

    }
}
