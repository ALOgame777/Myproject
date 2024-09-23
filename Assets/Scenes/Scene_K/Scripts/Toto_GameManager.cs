using UnityEngine;

public class Toto_GameManager : MonoBehaviour
{
    public TeamSelection teamSelection; // TeamSelection 스크립트를 참조

    private string selectedTeam;

    void Start()
    {
        selectedTeam = ""; // 초기 상태로 설정
    }

    public void SelectTeamA()
    {
        if (selectedTeam == "")
        {
            selectedTeam = "Team A";
            teamSelection.OnTeamASelected(); // 팀 A 선택 처리
        }
    }

    public void SelectTeamB()
    {
        if (selectedTeam == "")
        {
            selectedTeam = "Team B";
            teamSelection.OnTeamBSelected(); // 팀 B 선택 처리
        }
    }

    public string GetSelectedTeam()
    {
        return selectedTeam;
    }
}
