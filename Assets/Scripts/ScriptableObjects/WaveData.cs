using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObject/WaveData",order = 1)]
public class WaveData : ScriptableObject
{
    [SerializeField]
    float waveDuringTime;
    public float WaveDuringTime { get { return waveDuringTime; } }

    const int STARTWAVE = 1;
    public int StartWave { get { return STARTWAVE; } }

    [SerializeField]
    int startingUnitNumber;
    public int StartingUnitNumber { get { return startingUnitNumber; } }

    [SerializeField]
    int unitIncreaseWidth;
    public int UnitIncreaseWidth { get { return unitIncreaseWidth; } }

    [SerializeField]
    int startUnitHp;
    public int StartUnitHp { get { return startUnitHp; } }

    [SerializeField]
    int unitHpIncreaseWidth;
    public int UnitHpIncreaseWidth { get { return unitHpIncreaseWidth; } }
}
