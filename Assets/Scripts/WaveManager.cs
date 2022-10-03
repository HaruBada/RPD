using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : Singleton<WaveManager>
{
    public TextMeshProUGUI uiWave;
    public TextMeshProUGUI uiWaveTime;

    int wave;

    [SerializeField]
    float waveduringTime;

    // Start is called before the first frame update
    void Start()
    {
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
            

            yield return new WaitForSeconds(1.0f);
        }

    }
}
