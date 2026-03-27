using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundMusicSource;
    [SerializeField] Slider MusicVolumeSlider;
    bool MusicIsPlaying = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackgroundMusicSource.loop = true;
        
        if (MusicIsPlaying == false)
        {
            BackgroundMusicSource.volume = 1.0f;
            BackgroundMusicSource.Play();
            MusicIsPlaying = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicVolumeChange()
    {
        BackgroundMusicSource.volume = MusicVolumeSlider.value;
    }
}
