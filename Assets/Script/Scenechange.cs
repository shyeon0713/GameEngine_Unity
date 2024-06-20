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
        // �����Ϳ��� ���� ���� ���� �����͸� �����մϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ӿ����� ���ø����̼��� �����մϴ�.
        Application.Quit();
#endif
    }
    private IEnumerator PlaySoundAndChangeScene()
    {
        audio.Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1); // �Ǵ� SceneManager.LoadScene("SceneName");
    }
}
