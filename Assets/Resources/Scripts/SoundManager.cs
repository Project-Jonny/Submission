using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioClip[] audioClipsBGM;
    public AudioSource audioSourceSE;
    public AudioClip[] audioClipsSE;

    string sceneName = "";

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayBGM(string sceneName)
    {
        if (this.sceneName == sceneName)
        {
            return;
        }
        this.sceneName = sceneName;

        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;

            case "GameOver":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;

            case "Stage":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;

            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}