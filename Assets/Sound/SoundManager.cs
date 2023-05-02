using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> sounds = new List<AudioSource>();

    #region SINGLETON
    public static SoundManager instance { get; private set; }
    #endregion

    #region AWAKE
    private void Awake()
    {

        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente

        instance = this;
    }
    #endregion

    public void PlaySound(int index)
    {
        if (!sounds[index].isPlaying)
        {
            sounds[index].Play();
        }
    }

}
