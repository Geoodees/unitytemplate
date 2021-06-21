using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject loadingInterface;
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public Animator transition;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public void PlayGame()
    {
        //HideMenu();
        
        scenesToLoad.Add(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
        // scenesToLoad.Add(SceneManager.LoadSceneAsync(Level1Part1, LoadSceneMode.Additive));
        StartCoroutine(LoadingScene());
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }

    public void ShowLoadScene()
    {
        loadingInterface.SetActive(true);
    }

    IEnumerator LoadingScene()
    {
        transition.SetTrigger("Start");
        ShowLoadScene();

        yield return new WaitForSeconds(3);

        float totalProgress = 0;

        for(int i=0; i<scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += Mathf.Clamp01(scenesToLoad[i].progress / 0.9f);

                progressBar.value = totalProgress / scenesToLoad.Count;
                progressText.text = totalProgress / scenesToLoad.Count * 100f + "%";

                yield return null;
            }
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
