using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpeningScreenScript : MonoBehaviour
{
    [SerializeField]
    private float TIME_TO_FADE = 2; //<<< time for the title text to fade in and out
    [SerializeField]
    private float TIME_TO_STAY = 2f; //<<< time for the title text to stay completely shown
    protected float current_alpha = 0; //<<< opacity of the title text at a given frame
    private TextMeshProUGUI text; //<<< title text

    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        //launch the fading in coroutine
        StartCoroutine(StartFade());
    }

    //fading in coroutine, launches EndFade when done
    IEnumerator StartFade()
    {
        while (current_alpha < 1)
        {
            current_alpha += Time.deltaTime / TIME_TO_FADE;
            text.color = new Color(1, 1, 1, current_alpha);
            yield return null;
        }
        //keep the title displayed for the wanted time
        yield return new WaitForSeconds(TIME_TO_STAY);
        //launch the fading out coroutine
        StartCoroutine(EndFade());
    }

    //fading out coroutine, launches LoadMainScene when done
    IEnumerator EndFade()
    {
        while (current_alpha > 0)
        {
            current_alpha -= Time.deltaTime / TIME_TO_FADE;
            text.color = new Color(1, 1, 1, current_alpha);
            yield return null;
        }
        StartCoroutine(LoadMainScene());
    }

    //coroutine to transition to the main scene
    IEnumerator LoadMainScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
