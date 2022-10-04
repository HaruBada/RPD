using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : Singleton<WaveManager>
{
    public TextMeshProUGUI uiWave;
    public TextMeshProUGUI uiWaveTime;

    int wave;
    float timer;

    [SerializeField]
    float waveduringTime;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        timer = waveduringTime;
        uiWaveTime.text = Mathf.Floor(waveduringTime / 60) + " : " + waveduringTime % 60;
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
                timer = waveduringTime;
                wave += 1;
                uiWave.text = "Wave : " + wave;
            }

            yield return new WaitForSeconds(1.0f);

            timer -= 1;
            uiWaveTime.text = Mathf.Floor(timer / 60) + " : " + timer % 60;
        }

    }
}
