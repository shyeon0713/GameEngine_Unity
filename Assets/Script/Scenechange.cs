using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            StartCoroutine(PlaySoundAndChangeScene());
        }
    }

    private IEnumerator PlaySoundAndChangeScene()
    {
        audio.Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1); // ¶Ç´Â SceneManager.LoadScene("SceneName");
    }
}
