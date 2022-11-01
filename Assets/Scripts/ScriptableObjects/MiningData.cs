using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiningData",menuName ="ScriptableObject/MiningData",order = 2)]
public class MiningData : ScriptableObject
{
    const int startMiningPower = 0;
    public int StartMiningPower { get { return startMiningPower; } }

    [SerializeField]
    int maxMiningPower;
    public int MaxMiningPower { get { return maxMiningPower; } }

    [SerializeField]
    float mineralIncreaseRate;
    public float MineralIncreaseRate { get { return mineralIncreaseRate; } }


}
