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

    public bool isInvicible;

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

        GameManager.OnGameStateChanged += PlayerOnStateChanged;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChanged -= PlayerOnStateChanged;
    }

    void Start()
    {   
        SetValue(playerData);
        isInvicible = false;
    }
    
    public void PlayerOnStateChanged(GameState newState) {
        Player.instance.playerCurrentHealth = Player.instance.playerHealth;
        if (newState == GameState.PlayState) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
            
        }
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            playerAttackComponent.LightAttack(playerDamage, playerCritRate);
        }

        if (Input.GetMouseButtonDown(1)) {
            playerAttackComponent.Special();
        }

        // playerCurrentHealth -= Time.deltaTime * 0.2f * WaveManager.Instance.wave;
        if (!isInvicible) playerCurrentHealth -= Time.deltaTime;
        if (playerCurrentHealth <= 0) {
            Dead();
        }

        healthSystem.hitPoint = playerCurrentHealth;
        pointCounts.text = GameManager.instance.points[0].ToString();
    }


    public void PlayerHitted(float counterDamage) {
        playerCurrentHealth -= counterDamage - playerArmor;
    }

    public void Dead() {
        GameManager.instance.UpdateGameState(GameState.DeadState);
    }
}
