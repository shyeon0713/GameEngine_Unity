using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer button;   //button1 (맨 왼쪽)

    public Sprite defaultImage;  //default sprite _Image
    public Sprite PressImage;  // press sprite _Image

    AudioSource audio;  //효과음

    public KeyCode KeyToPress;
   // public KeyCode KeyToPress;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            button.sprite = PressImage;
            audio.Play();
        }
        if (Input.GetKeyUp(KeyToPress))
        {
            button.sprite = defaultImage;
        }
    }
}
