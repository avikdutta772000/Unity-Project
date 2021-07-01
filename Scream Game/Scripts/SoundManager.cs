using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public float sensitivity = 100f;
    public float minSensitivity;
    public float maxSensitivity;
    public float loudness;
    AudioSource audio;
    public float threshold = 0;
    public float jumpForce = 4f;
    public GameObject slider;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(null, true, 10, 44100);//device name;loop;time in sec;freq;
        audio.loop = true;
        //audio.mute = true;
        while(!(Microphone.GetPosition(null)>0))
        {
        }
        audio.Play();
        slider.GetComponent<Slider>().minValue = minSensitivity;
        slider.GetComponent<Slider>().maxValue = maxSensitivity;
        slider.GetComponent<Slider>().value = sensitivity;
    }
    void Update()
    {
        sensitivity = slider.GetComponent<Slider>().value;
        loudness = GetAverageVolume() * sensitivity;
        if(loudness>threshold)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }
    }

    float GetAverageVolume()
    {
        float[] data = new float[256];
        float a=0f;
        audio.GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
