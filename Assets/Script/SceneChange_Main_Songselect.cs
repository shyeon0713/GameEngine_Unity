using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Main_Songselect : MonoBehaviour
{
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Next() { 
   
        SceneManager.LoadScene(2);  // Songselect������ �̵�
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);   //Title������ �̵�
        }
        if (Input.anyKeyDown)
        {
            audio.Play();
        }
    }
}
