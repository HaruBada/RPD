using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : Singleton<WaveManager>
{
    public TextMeshProUGUI uiWave;
    public TextMeshProUGUI uiWaveTime;

    [SerializeField]
    WaveData waveData;

    int wave;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        wave = waveData.StartWave;
        timer = waveData.WaveDuringTime;
        uiWaveTime.text = Mathf.Floor(timer / 60) + " : " + timer % 60;
        StartCoroutine("Wave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wave()
    {
        while(true)
        {
            if(timer == 0)
            {
                timer = waveData.WaveDuringTime;
                wave += 1;
                uiWave.text = "Wave " + wave;
            }

            yield return new WaitForSeconds(1.0f);

            timer -= 1;
            uiWaveTime.text = Mathf.Floor(timer / 60) + " : " + timer % 60;
        }

    }
}
