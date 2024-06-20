using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueLines = {
        "어서오세요, 호환입니다",
        "앗! 오늘은 일찍 출근하셨네요ㅎㅎ",
        "사장님은 지금 정산 중 이세요!",
        "어디보자.. 오늘 예약손님은 한분이네요!",
        "한분이지만 저 손님 누군가에 대한 한이 심하게 남아있는것 같아요..",
        "오늘도 잘 하실 수 있죠?",
        "곡은 아련하고 여운이 남는   {서리꽃}으로 부탁드려요!",
        "(쉐이커를 눌러 곡을 선택해주세요)"
    };

    private int currentLine = 0; // 현재 대화 라인 인덱스

    public TextMeshProUGUI dialogueText; // 대화 내용을 표시할 텍스트
    public Button nextButton; // 대화를 진행할 버튼

    void Start()
    {
        dialogueText.gameObject.SetActive(false); // 시작할 때 대화 UI 비활성화
        nextButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(DisplayNextLine); // 버튼 클릭 시 DisplayNextLine 호출

        StartDialogue(); // 씬이 시작되자마자 대화 시작
    }

    private void StartDialogue()
    {
        dialogueText.gameObject.SetActive(true); // 대화 UI 활성화
        nextButton.gameObject.SetActive(true);
        currentLine = 0;
        DisplayNextLine();
    }

    private void DisplayNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false); // 대화 UI 비활성화
        nextButton.gameObject.SetActive(false);
    }
}