using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButtonsScript : MonoBehaviour
{
    public string detectedPosterScene;//<<<stocks the current poster scene given by the PosterTracking script
    public string detectedPosterLink;//<<<stocks the current poster link given by the PosterTracking script

    //---------------------------------------------------------------------
    //Functions for scene management

    //General coroutine to load any scene by its name, DO NOT USE BETWEEN 2 AR SCENES
    IEnumerator LoadSceneRoutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
    }

    //AR scenes switching requires the AR session reloading, can't be done with an async coroutine
    public void LoadARScene(string sceneName)
    {
        var xrManagerSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();
        SceneManager.LoadScene(sceneName);
        xrManagerSettings.InitializeLoaderSync();
    }

    //Launches coroutine with the give scene name in parameters
    public void ChangeScene(string scene)
    {
        StartCoroutine(LoadSceneRoutine(scene));
    }

    //Launches the function to load a scene with the detectedPosterScene public variable
    public void ChangeSceneToPoster()
    {
        if (detectedPosterScene == null) return;

        //switch between 2 AR scenes, requires the specific function
        //StartCoroutine(LoadScene(detectedPosterScene));
        LoadARScene(detectedPosterScene);
    }
    //-------------------------------------------------------------------------


    //Open videos/websites function
    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    //similar to OpenLink but with the detectedPosterLink public variable
    public void OpenPosterLink()
    {
        Application.OpenURL(detectedPosterLink);
    }


    //Quits the app
    public void Quit()
    {
        //Debug.Log("Quit!");
        Application.Quit();
    }
}
