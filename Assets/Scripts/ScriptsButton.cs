using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptsButton : MonoBehaviour
{
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

    public void ChangeScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
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
        Debug.Log("Quit!");
        Application.Quit();
    }

    //-----------------------------------------------------------------------------------
    //DEPRECATED BAD PRACTICE CODE
/*
public void Next()
{

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

public void NextCercle2()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
}

public void NextCercle3()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
}

public void NextCercle4()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
}

public void NextCercle5()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
}

public void NextCercleVideo()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
}

public void NextPoster()
{
    SceneManager.UnloadSceneAsync(4);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
}

public void Poster()
{
    SceneManager.LoadScene(4);
}

public void DialoguePoster2()
{
    SceneManager.LoadScene(4);
}

public void DialoguePoster()
{
    SceneManager.LoadScene(6);
}


public void Back()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
}

public void BackCercle()
{

    SceneManager.LoadScene(2);
}
public void BackCercle2()
{

    SceneManager.LoadScene(1);
}

public void OnMouseOver()
{
    if (Input.GetMouseButtonUp(0))
    {
        SceneManager.LoadScene(1);
    }
}

*/
/*
public void LoadSearchScene()
{
    StartCoroutine(LoadScene(AGRI_SEARCH));
}

public void LoadInfoScene()
{
    StartCoroutine(LoadScene(AGRI_INFO));
}

public void LoadEventScene()
{
    StartCoroutine(LoadScene(EVENT));
}

public void LoadHomeScene()
{
    StartCoroutine(LoadScene(HOME));
}

public void LoadDFScene()
{
    StartCoroutine(LoadScene(DF));
}*/
//Scene names for a centralized scene management
/*const string HOME = "HomeScene";
const string EVENT = "EventScene";
const string AGRI_SEARCH = "AgriPosterSearchScene";
const string AGRI_INFO = "AgriPosterInfoScene";
const string DF = "DFPosterScene";*/
/*public void OpenVideo(){
    Application.OpenURL("https://www.youtube.com/watch?v=op3ClLHHehU&ab_channel=MattHumanPizza2");
}

public void OpenLinkIso(){
    Application.OpenURL("https://fr.wikipedia.org/wiki/ISO_11783");
}

public void OpenLinkPoster(){
    Application.OpenURL("https://leonar.interleo.eu/posters/");
}

public void OpenLinkPoster2(){
    Application.OpenURL("https://leonar.interleo.eu/posters/");
}

public void OpenUTBMLink(){
    Application.OpenURL("https://www.utbm.fr");
}

public void OpenTUKLink(){
    Application.OpenURL("https://www.uni-kl.de");
}

public void OpenSCAULink(){
    Application.OpenURL("https://english.scau.edu.cn");
}*/
//----------------------------------------------------------------------------------
}
