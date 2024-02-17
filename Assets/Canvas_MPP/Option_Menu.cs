using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Option_Menu : MonoBehaviour
{
    [SerializeField] private AudioMixer Volume;
    public void ChangeVolume(float volume)
    {
        Volume.SetFloat("Volume", volume);
    }
}
