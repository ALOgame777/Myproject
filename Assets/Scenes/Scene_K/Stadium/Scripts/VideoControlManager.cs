using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControlManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;
    public Button stopButton;
    public Text statusText;

    void Start()
    {
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);
        pauseButton.onClick.AddListener(StopVideo);

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayVideo()
    {
        videoPlayer.Play();
        UpdateUI();
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
        UpdateUI();
    }

    void StopVideo()
    {
        videoPlayer.Stop();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (videoPlayer.isPlaying)
        {
            statusText.text = "재생중";
        }
        else if(videoPlayer.isPaused)
        {
            statusText.text = "일시정지";
        }
        else
        {
            statusText.text = "멈춤";
        }
    }
}
