using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpeningScreenScript : MonoBehaviour
{
    [SerializeField]
    private float TIME_TO_FADE = 2;
    [SerializeField]
    private float TIME_TO_STAY = 2f;
    protected float current_alpha = 0;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(StartFade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartFade()
    {
        while (current_alpha < 1)
        {
            current_alpha += Time.deltaTime / TIME_TO_FADE;
            text.color = new Color(1, 1, 1, current_alpha);
            yield return null;
        }
        yield return new WaitForSeconds(TIME_TO_STAY);
        StartCoroutine(EndFade());
    }
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

    IEnumerator LoadMainScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
