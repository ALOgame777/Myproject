using UnityEngine;
using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    public Image teamAImage; // 팀 A의 이미지 컴포넌트
    public Image teamBImage; // 팀 B의 이미지 컴포넌트
    public Sprite teamAColorSprite; // 팀 A의 컬러 이미지
    public Sprite teamAGraySprite; // 팀 A의 흑백 이미지
    public Sprite teamBColorSprite; // 팀 B의 컬러 이미지
    public Sprite teamBGraySprite; // 팀 B의 흑백 이미지

    private bool isTeamASelected = false;
    private bool isTeamBSelected = false;

    public void OnTeamASelected()
    {
        if (!isTeamASelected)
        {
            teamAImage.sprite = teamAColorSprite; // 컬러 이미지로 변경
            teamBImage.sprite = teamBGraySprite; // 상대 팀은 흑백 이미지 유지
            isTeamASelected = true;
            isTeamBSelected = false;
            // 베팅 완료 처리 로직 추가
            Debug.Log("Team A Selected");
        }
    }

    public void OnTeamBSelected()
    {
        if (!isTeamBSelected)
        {
            teamBImage.sprite = teamBColorSprite; // 컬러 이미지로 변경
            teamAImage.sprite = teamAGraySprite; // 상대 팀은 흑백 이미지 유지
            isTeamASelected = false;
            isTeamBSelected = true;
            // 베팅 완료 처리 로직 추가
            Debug.Log("Team B Selected");

        }
    }
}
