using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject menu;
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        menu.SetActive(false);
        loadingScreen.SetActive(true);

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
