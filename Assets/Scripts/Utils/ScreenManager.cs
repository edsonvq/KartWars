using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    [SerializeField]
    private float m_DelayAfterLaoding = 2.0f;

    public void LoadLevel(string nextSceneName)
    {
        StartCoroutine(ChangeScene(nextSceneName, false));
    }


    public IEnumerator ChangeScene(string nextSceneName, bool loading)
    {
        if (nextSceneName.Equals("Quit"))
        {
            Application.Quit();
        }
        else
        {

            AsyncOperation asyncScene = SceneManager.LoadSceneAsync(nextSceneName);
            asyncScene.allowSceneActivation = false;

            while (!asyncScene.isDone)
            {
                if (asyncScene.progress >= 0.9f)
                {

                    asyncScene.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}