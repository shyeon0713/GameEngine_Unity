using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject badEffect, goodEffect, perfectEffect,hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {

            if (canBePressed)
            {
                gameObject.SetActive(false);

                // GameManager.instance.NoteHit();

                // GameManager.instance.NoteHit();
                Debug.Log("Y Position: " + transform.position.y);

                if (transform.position.y < -2.2f && transform.position.y > -2.4f) // 히트이오 판정
                {
                    Debug.Log("Normal");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (transform.position.y < -2.4f && transform.position.y > -3.0f) // 굳이오 판정
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else if (transform.position.y < -3.0f && transform.position.y > -3.9f) // 퍼펙트이오 판정
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
                else if (transform.position.y < -3.9f) // 놓쳤소 판정
                {
                    Debug.Log("Missed");
                    GameManager.instance.NoteMissed();
                    Instantiate(badEffect, transform.position, badEffect.transform.rotation);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            GameManager.instance.NoteMissed();
          
            canBePressed = false;
        }
    }
    
}
