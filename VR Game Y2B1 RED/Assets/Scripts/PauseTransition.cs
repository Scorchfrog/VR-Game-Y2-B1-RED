using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuWithTransition : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject wristUI;
    public bool activeWristUI = true;

    [Header("Scene Transition Settings")]
    public FadeScreen fadeScreen; // Reference to your existing FadeScreen
    public static PauseMenuWithTransition singleton;

    private void Awake()
    {
        // Singleton pattern to persist or ensure single instance
        if (singleton && singleton != this)
        {
            Destroy(singleton.gameObject);
        }
        singleton = this;
    }

    void Start()
    {
        DisplayWristUI();
    }

    // Called by your Input Action
    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }

    // Toggles the wrist UI and pause state
    public void DisplayWristUI()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Time.timeScale = 1;
        }
        else
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Time.timeScale = 0;
        }
    }

    // Restart the current scene (with optional fade)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadPreviousScene()
    {
        int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (prevSceneIndex >= 0)
        {
            GoToScene(prevSceneIndex);
        }
    }

    // Go to a scene by index (with fade)
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    private IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        if (fadeScreen != null)
        {
            fadeScreen.FadeOut();
            yield return new WaitForSecondsRealtime(fadeScreen.fadeDuration);
        }

        Time.timeScale = 1; // Resume normal time before loading
        SceneManager.LoadScene(sceneIndex);
    }

    // Go to a scene asynchronously (with fade)
    public void GoToSceneAsync(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    private IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        if (fadeScreen != null)
            fadeScreen.FadeOut();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        float duration = fadeScreen != null ? fadeScreen.fadeDuration : 1f;

        while (timer <= duration && !operation.isDone)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
