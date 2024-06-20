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
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            StartCoroutine(PlaySoundAndChangeScene());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        // 에디터에서 실행 중일 때는 에디터를 중지합니다.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서는 애플리케이션을 종료합니다.
        Application.Quit();
#endif
    }
    private IEnumerator PlaySoundAndChangeScene()
    {
        audio.Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1); // 또는 SceneManager.LoadScene("SceneName");
    }
}
