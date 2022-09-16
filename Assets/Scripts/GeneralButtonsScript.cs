using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButtonsScript : MonoBehaviour
{
    public string detectedPosterScene;
    //---------------------------------------------------------------------
    //Functions for scene management

    //General coroutine to load any scene by its name
    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    //Launches coroutine with the give scene name in parameters
    public void ChangeScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    public void ChangeSceneToPoster()
    {
        if (detectedPosterScene == null) return;
        StartCoroutine(LoadScene(detectedPosterScene));
    }
    //-------------------------------------------------------------------------


    //Open videos/websites function
    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }


    //Quits the app
    public void Quit()
    {
        //Debug.Log("Quit!");
        Application.Quit();
    }
}
