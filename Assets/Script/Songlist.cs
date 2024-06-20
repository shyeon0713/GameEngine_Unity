using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite;
    public AudioClip audioClip;  // 곡의 오디오 클립
}
public class Songlist : MonoBehaviour
{
        [SerializeField] Song[] songList = null;

        [SerializeField] TextMeshProUGUI Songname = null;   // 곡이름
        [SerializeField] TextMeshProUGUI SongComposer = null;   //작곡가 이름
        [SerializeField] Image imgDisk = null;   //곡 이미지
        [SerializeField] AudioSource audioSource = null;   // 오디오 소스

        int currentSong = 0;   // 현재 곡 넘버(변수)

        void Start()
        {
            SettingSong();
        }
        public void BtnNext()
        {
            if (++currentSong > songList.Length - 1)

                currentSong = 0;
            SettingSong();

        }

        public void BtnPrior()
        {
            if (--currentSong < 0)

                currentSong = songList.Length - 1;
            SettingSong();

        }

        void SettingSong()
        {
            Songname.text = songList[currentSong].name;
            SongComposer.text = songList[currentSong].composer;
            imgDisk.sprite = songList[currentSong].sprite;

            if (audioSource != null && songList[currentSong].audioClip != null)
            {
                audioSource.clip = songList[currentSong].audioClip;
                audioSource.Play();
            }

        }
}
    // Start is called before the first frame update


