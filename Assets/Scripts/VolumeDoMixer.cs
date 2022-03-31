using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeDoMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string parametroDoMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey(parametroDoMixer))
        {
            _mixer.SetFloat(parametroDoMixer, PlayerPrefs.GetFloat(parametroDoMixer));
        }
        else
        {
            _mixer.SetFloat(parametroDoMixer, 0);
        }
    }

    // Start is called before the first frame update
    public void MudarVolume(float volume)
    {
        _mixer.SetFloat(parametroDoMixer, volume);
        PlayerPrefs.SetFloat(parametroDoMixer, volume);
    }
}
