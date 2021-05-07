using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public bool isMute;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            if (PlayerPrefs.GetFloat("music") == 0)
            {
                AudioListener.volume = 0f;
                gameObject.GetComponent<Toggle>().isOn = true;
            }
            else if (PlayerPrefs.GetFloat("music") == 1)
            {
                AudioListener.volume = 1f;
                gameObject.GetComponent<Toggle>().isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("music",1);
            gameObject.GetComponent<Toggle>().isOn = false;
        }
    }

    public void MuteToggle()
    {
        isMute = !isMute;
        if (isMute == true)
        {
            AudioListener.volume = 0f;
            PlayerPrefs.SetFloat("music", 0);
        }
        else
        {
            AudioListener.volume = 1f;
            PlayerPrefs.SetFloat("music", 1);
        }
    }
}
