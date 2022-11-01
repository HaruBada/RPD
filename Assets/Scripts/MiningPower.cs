using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiningPower : MonoBehaviour
{
    public TextMeshProUGUI uiMiningPower;
    public TextMeshProUGUI uiMineral;
    PropertyManager propertyManager;

    [SerializeField]
    MiningData miningData;

    int miningPower;

    // Start is called before the first frame update
    void Start()
    {
        propertyManager = PropertyManager.Instance;
        miningPower = miningData.StartMiningPower;
        StartCoroutine("Mining");
    }

    IEnumerator Mining()
    {
        while(true)
        {
            propertyManager.Mineral = Mathf.RoundToInt(propertyManager.Mineral + miningData.MineralIncreaseRate * (miningPower+1));
            uiMineral.text = "mineral : " + propertyManager.Mineral;
            yield return new WaitForSeconds(1.0f);
        }

    }

    public void MiningPowerUpgrateButton()
    {
        if (miningPower == miningData.MaxMiningPower)
        {
            Debug.Log("Max Mining Power! current mining power is " + miningPower);
            return;
        }
        miningPower += 1;
        uiMiningPower.text = "Mining Power Upgrate : " + miningPower + "/" + miningData.MaxMiningPower;
    }

}
