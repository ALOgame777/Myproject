using UnityEngine;
using UnityEngine.UI;

public class TeamSelectionManager : MonoBehaviour
{
    public Slider teamAProgressBar; // 팀 A의 선택 비율을 나타낼 슬라이더
    public Text teamASliderText;    // 슬라이더 바 위에 표시될 텍스트 (팀 A)

    public Slider teamBProgressBar; // 팀 B의 선택 비율을 나타낼 슬라이더
    public Text teamBSliderText;    // 슬라이더 바 위에 표시될 텍스트 (팀 B)

    private int teamASelections = 0; // 팀 A 선택 수
    private int teamBSelections = 0; // 팀 B 선택 수

    void Start()
    {
        // 슬라이더 값이 변경될 때마다 텍스트를 업데이트하도록 리스너를 추가합니다.
        teamAProgressBar.onValueChanged.AddListener(UpdateTeamAText);
        teamBProgressBar.onValueChanged.AddListener(UpdateTeamBText);
    }

    public void SelectTeamA()
    {
        teamASelections++; // 팀 A 선택 수 증가
        UpdateUI();        // UI 업데이트

    }

    public void SelectTeamB()
    {
        teamBSelections++; // 팀 B 선택 수 증가
        UpdateUI();        // UI 업데이트

    }

    private void UpdateUI()
    {
        int totalSelections = teamASelections + teamBSelections;

        // 팀 A와 팀 B의 선택 비율을 계산합니다. 퍼센트는 정수로 계산합니다.
        int teamAPercent = (totalSelections == 0) ? 0 : Mathf.RoundToInt((float)teamASelections / totalSelections * 100);
        int teamBPercent = (totalSelections == 0) ? 0 : Mathf.RoundToInt((float)teamBSelections / totalSelections * 100);

        // 슬라이더 값 업데이트
        teamAProgressBar.value = teamAPercent;
        teamBProgressBar.value = teamBPercent;
    }

    private void UpdateTeamAText(float value)
    {
        // 팀 A의 슬라이더 위에 퍼센트 텍스트를 업데이트합니다. 소수점 없이 정수로 표시합니다.
        teamASliderText.text = $"{Mathf.RoundToInt(value)}%";
    }

    private void UpdateTeamBText(float value)
    {
        // 팀 B의 슬라이더 위에 퍼센트 텍스트를 업데이트합니다. 소수점 없이 정수로 표시합니다.
        teamBSliderText.text = $"{Mathf.RoundToInt(value)}%";
    }
}
