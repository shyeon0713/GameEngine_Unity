using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueLines = {
        "�������, ȣȯ�Դϴ�",
        "��! ������ ���� ����ϼ̳׿䤾��",
        "������� ���� ���� �� �̼���!",
        "�����.. ���� ����մ��� �Ѻ��̳׿�!",
        "�Ѻ������� �� �մ� �������� ���� ���� ���ϰ� �����ִ°� ���ƿ�..",
        "���õ� �� �Ͻ� �� ����?",
        "���� �Ʒ��ϰ� ������ ����   {������}���� ��Ź�����!",
        "(����Ŀ�� ���� ���� �������ּ���)"
    };

    private int currentLine = 0; // ���� ��ȭ ���� �ε���

    public TextMeshProUGUI dialogueText; // ��ȭ ������ ǥ���� �ؽ�Ʈ
    public Button nextButton; // ��ȭ�� ������ ��ư

    void Start()
    {
        dialogueText.gameObject.SetActive(false); // ������ �� ��ȭ UI ��Ȱ��ȭ
        nextButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(DisplayNextLine); // ��ư Ŭ�� �� DisplayNextLine ȣ��

        StartDialogue(); // ���� ���۵��ڸ��� ��ȭ ����
    }

    private void StartDialogue()
    {
        dialogueText.gameObject.SetActive(true); // ��ȭ UI Ȱ��ȭ
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
        dialogueText.gameObject.SetActive(false); // ��ȭ UI ��Ȱ��ȭ
        nextButton.gameObject.SetActive(false);
    }
}