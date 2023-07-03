using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sound : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static TextMeshProUGUI staticText;
    public static bool sound = true;
    // Start is called before the first frame update
    void Start()
    {
        staticText = text;
        if(sound)
        {
            AudioListener.volume = 1;
            staticText.text = "Mute Sound";
        }
        else
        {
            AudioListener.volume = 0;
            staticText.text = "Unmute Sound";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ToggleSound()
    {
        sound = !sound;
        if(sound)
        {
            AudioListener.volume = 1;
            staticText.text = "Mute Sound";
        }
        else
        {
            AudioListener.volume = 0;
            staticText.text = "Unmute Sound";
        }
        
    }

   
}
