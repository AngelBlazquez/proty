using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the background music of the game
/// Author : Angel Blazquez
/// </summary>
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] allMusicsInOrder; 

    [SerializeField]
    private int menuLevelOffset = 3; // Escape the first Menu levels in the build settings
    
    private int currentIndex;

    /// <summary>
    /// Play a song depending on the level index
    /// </summary>
    /// <param name="index">Index of the level in the build settings</param>
    public void PlayLevelSong(int index)
    {
        AudioSource internalAudioPlayer = GetComponent<AudioSource>();

        currentIndex = index;
        Debug.Log(index - 3);
        internalAudioPlayer.Stop();
        internalAudioPlayer.clip = allMusicsInOrder[index-menuLevelOffset];
        internalAudioPlayer.Play();
    }

    public int GetCurrentIndex() { return currentIndex; }
}
