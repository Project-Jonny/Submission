using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private bool firstPush = false;

    private void Start()
    {
        SoundManager.instance.PlayBGM("Title");
    }

    void Update()
    {
        if (!firstPush)
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.D))
            {
                firstPush = true;
                FadeIOManager.instance.FadeOutToIn(() => SMD());
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                firstPush = true;
                FadeIOManager.instance.FadeOutToIn(() => Move());
            }
        }
    }

    void Move()
    {
        SceneManager.LoadScene("Main");
    }

    void SMD()
    {
        SceneManager.LoadScene("SMD");
    }
}