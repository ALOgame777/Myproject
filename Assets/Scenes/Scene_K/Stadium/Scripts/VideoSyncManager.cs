using UnityEngine;
using Photon.Pun;
using UnityEngine.Video;

public class VideoSyncManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public VideoPlayer videoPlayer;
    public string videoUrl = "Your YouTube video URL";
    private double currentVideoTime;
    private bool isPlaying = false;

    void Start()
    {
        videoPlayer.url = videoUrl; // YouTube URL 설정
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare(); // 비디오 준비
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            videoPlayer.Play(); // 마스터 클라이언트가 영상을 재생
            isPlaying = true;
        }
    }

    void Update()
    {
        // 마스터 클라이언트가 시간 동기화
        if (PhotonNetwork.IsMasterClient)
        {
            currentVideoTime = videoPlayer.time;
        }
        else
        {
            videoPlayer.time = currentVideoTime; // 다른 플레이어들은 마스터 클라이언트의 시간을 기준으로 재생
            if (!isPlaying && currentVideoTime > 0)
            {
                videoPlayer.Play();
                isPlaying = true;
            }
        }
    }

    // IPunObservable 인터페이스의 필수 메서드 구현
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 마스터 클라이언트가 재생 시간을 다른 클라이언트에 전송
            stream.SendNext(currentVideoTime);
            stream.SendNext(isPlaying);
        }
        else
        {
            // 다른 클라이언트에서 마스터 클라이언트의 재생 시간과 상태를 수신
            currentVideoTime = (double)stream.ReceiveNext();
            isPlaying = (bool)stream.ReceiveNext();
        }
    }
}
