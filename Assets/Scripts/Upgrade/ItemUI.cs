using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public TMP_Text tmp, tmpUpgradeCount;
    public UpgradeStat itemStat;
    void Start(){
        
    }
    void Update(){
        tmp.text = $"{GameManager.instance.points[0]}/{UpgradeManager.Instance.cost}";
        tmpUpgradeCount.text = $"{UpgradeManager.Instance.statsName[(int)itemStat]} Upgrade Count : {UpgradeManager.Instance.upgradePoints[(int)itemStat]}";
    }
    public void Upgrade(){
        GameManager g = GameManager.instance;
        UpgradeManager u = UpgradeManager.Instance;
        if (u.cost <= g.points[0]){
            g.points[0] -= UpgradeManager.Instance.cost;
            u.upgradePoints[(int)itemStat]++;
        }
        else{
            Debug.Log("Not enough points");
        }
    }
}
