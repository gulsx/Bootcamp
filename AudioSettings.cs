using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    public Text volumeAmount;
    
    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        volumeAmount.text = ((int)value*100).ToString();
    }

}
