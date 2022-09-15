using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiningPower : MonoBehaviour
{
    public TextMeshProUGUI uiMiningPower;
    public TextMeshProUGUI uiMineral;
    PropertyManager propertyManager;

    int miningPower;
    int maxMiningPower = 100;

    // 미네랄 증가율
    int mineralIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        propertyManager = PropertyManager.Instance;
        miningPower = 0;
        mineralIncreasing = 10;
        StartCoroutine("Mining");
    }

    IEnumerator Mining()
    {
        while(true)
        {
            propertyManager.Mineral += mineralIncreasing;
            uiMineral.text = "mineral : " + propertyManager.Mineral;
            yield return new WaitForSeconds(1.0f);
        }

    }

    public void MiningPowerUpgrateButton()
    {
        if (miningPower == maxMiningPower)
        {
            Debug.Log("Max Mining Power! current mining power is " + miningPower);
            return;
        }
        miningPower += 1;
        mineralIncreasing += 1;
        uiMiningPower.text = "Mining Power Upgrate : " + miningPower + "/" + maxMiningPower;
    }

}
