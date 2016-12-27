using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace NKM.RPGFramework
{
    public class SceneController : MonoBehaviour
    {
        public CanvasGroup faderCanvasGroup;
        public float fadeDuration = 1f;
        public string startingSceneName = "main";


        private bool isFading;


        private IEnumerator Start()
        {
            faderCanvasGroup.alpha = 1f;

            yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName));

            StartCoroutine(Fade(0f));
        }


        public void FadeAndLoadScene(string sceneName)
        {
            if (!isFading)
            {
                StartCoroutine(FadeAndSwitchScenes(sceneName));
            }
        }


        //Fades out screen and closes the application
        public IEnumerator FadeOutEndGame()
        {
            //Start FadeOut and wait until its done
            yield return StartCoroutine(Fade(1f));
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            //Quit the application
            Application.Quit();
        }


        private IEnumerator FadeAndSwitchScenes(string sceneName)
        {
            yield return StartCoroutine(Fade(1f));

            //SaveAllPersistentData();

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            yield return StartCoroutine(LoadSceneAndSetActive(sceneName));

            //LoadAllPersistentData();

            yield return StartCoroutine(Fade(0f));
        }


        private IEnumerator LoadSceneAndSetActive(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newlyLoadedScene);
        }


        private IEnumerator Fade(float finalAlpha)
        {
            isFading = true;
            faderCanvasGroup.blocksRaycasts = true;

            float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

            while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
            {
                faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha,
                    fadeSpeed * Time.deltaTime);

                yield return null;
            }

            isFading = false;
            faderCanvasGroup.blocksRaycasts = false;
        }


        private void SaveAllPersistentData()
        {
            //PersistentDataController[] persistentDataControllers = FindObjectsOfType<PersistentDataController>();
            //for (int i = 0; i < persistentDataControllers.Length; i++)
            //{
            //    persistentDataControllers[i].Save();
            //}
        }


        private void LoadAllPersistentData()
        {
            // PersistentDataController[] persistentDataControllers = FindObjectsOfType<PersistentDataController>();
            // for (int i = 0; i < persistentDataControllers.Length; i++)
            // {
            //     persistentDataControllers[i].Load();
            // }
        }
    }
}