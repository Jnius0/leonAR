using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    //avoids having several coroutines launched if the button is spammed
    private bool active = false;
    public void ChangeLocale(int localeID)
    {
        //avoids having several coroutines launched if the button is spammed
        if (active == true) return;
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int _localeID)
    {
        //avoids having several coroutines launched if the button is spammed
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        //remember the player choice
        PlayerPrefs.SetInt("LocaleKey", _localeID);
        active = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //initialize the saved language
        ChangeLocale(PlayerPrefs.GetInt("LocaleKey", 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
