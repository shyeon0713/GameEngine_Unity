using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public Arrow theBS;    //bearscroller == arrow 

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 1;
    public int scorePerGoodNote = 3;
    public int scorePerPerfectNote = 5;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public TextMeshProUGUI  normalText, goodText, perfectText, missText, finalScorText, percentHitText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "점수 : 0";

        totalNotes = FindObjectsOfType<NoteObject>().Length;
        resultsScreen.SetActive(false);  // 게임 시작 시 결과 화면 비활성화

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.GetMouseButtonDown(0) ) //왼쪽마우스 누르면 시작
            {
                startPlaying = true;  //노래 시작하기
                theBS.hasStarted = true; //Arrow 스크립트에서 hasStarted 변수를 true로 변환

                theMusic.Play();

            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                normalText.text = "" + normalHits;
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                if(percentHit > 60.0f)
                {
                    finalScorText.text = "총점수 :" + currentScore;
                    percentHitText.text = "해원성공";
                }
                else
                {
                    finalScorText.text = "총점수 :" + currentScore;
                    percentHitText.text = "해원실패";
                }
            }
        }
    }

    public void NoteHit()
    {
      
       // currentScore += scorePerNote;
        scoreText.text = "점수 :  " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();

        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        currentScore += scorePerNote * 0;
        Debug.Log("Missed Note");

        missedHits++;
    }


}
