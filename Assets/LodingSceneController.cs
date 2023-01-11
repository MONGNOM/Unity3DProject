using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingSceneController : MonoBehaviour
{
    [SerializeField]
    private Image Progressbar;

    static string nextScene;

    
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene ("LodingScene");

    }

    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }
    IEnumerator LoadSceneProcess()
    {
       AsyncOperation op =  SceneManager.LoadSceneAsync(nextScene);
       op.allowSceneActivation = false;

        float Timer = 0f; 
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.3f)
            {
                Progressbar.fillAmount = op.progress;
            }
            else
            {
                Timer += Time.unscaledDeltaTime;
                Progressbar.fillAmount = Mathf.Lerp(0.3f, 1f, Timer);
                if (Progressbar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }


}
