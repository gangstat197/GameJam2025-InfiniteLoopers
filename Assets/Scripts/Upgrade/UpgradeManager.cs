using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeStat{
    Damage,
    Speed,
    Armor,
    Health
}
public class UpgradeManager : Singleton<UpgradeManager>
{
    public List<int> upgradePoints = new List<int>();
    public List<string> statsName = new List<string>();
    public int cost = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Upgrade(UpgradeStat upgradeStat){
        if (GameManager.instance.points[0] >= cost){
            GameManager.instance.points[0] -= cost;
            upgradePoints[(int)upgradeStat]++;
        }
        else{
            Debug.Log("Not enough point");
        }
    }
}
