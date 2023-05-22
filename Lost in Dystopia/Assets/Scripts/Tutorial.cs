using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    bool isActivated = false;
    public GameObject RawImage;
    public VideoPlayer VideoPlayer;
    public void VideoUpdater()
    {
        if (isActivated)
        {
            RawImage.SetActive(false);
            isActivated = false;
            VideoPlayer.Stop();
        }
        else
        {
            RawImage.SetActive(true);
            isActivated = true;
            VideoPlayer.Play();
        }
    }

}
