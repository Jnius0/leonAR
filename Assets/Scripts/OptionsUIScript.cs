using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class OptionsUIScript : MonoBehaviour
{
    [Header("Provide the options layout child(its button children will automatically be parsed).")]
    [SerializeField]
    private GameObject optionsUI;
    [Header("Provide the alternative top UI so that it can be disabled when options are open.")]
    [SerializeField]
    private Canvas alternativeTopUI;
    private List<Button> optionsButtons;//<<< list of the buttons children of the optionsUI canvas
    private Animator animator;//<<< animator component to launch the scroll animations
    private bool changingLanguage = false;//<<< avoids having several coroutines launched if the button is spammed

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        //initialize the saved language
        ChangeLocale(PlayerPrefs.GetInt("LocaleKey", 0));
        optionsButtons = GetChildrenButtons(GetChildren(this.optionsUI.transform));
        SetChildrenButtonsActive(false);
    }

    //----------------------------------------------------------------
    //children management functions

    //returns a list of the children of a gameobject (the transofrm of it must be given)
    private List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();

        foreach(Transform child in parent)
        {
            children.Add(child);
            //Debug.Log(child.name);
        }

        return children;
    }

    //extracts the list of buttons from a list of children
    private List<Button> GetChildrenButtons(List<Transform> children)
    {
        List<Button> childrenButtons = new List<Button>();
        Button temp;

        foreach(Transform child in children)
        {
            temp = child.GetComponent<Button>();
            if (temp != null)
            {
                childrenButtons.Add(temp);
            }
        }

        return childrenButtons;
    }

    //simple loop to set the list of buttons active or not
    private void SetChildrenButtonsActive(bool isActive)
    {
        foreach(Button button in this.optionsButtons)
        {
            button.enabled = isActive;
        }
    }

    //---------------------------------------------------------------------
    //Language settings handling
    public void ChangeLocale(int localeID)
    {
        //avoids having several coroutines launched if the button is spammed
        if (changingLanguage == true) return;
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int _localeID)
    {
        //avoids having several coroutines launched if the button is spammed
        changingLanguage = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        //remember the player choice
        PlayerPrefs.SetInt("LocaleKey", _localeID);
        changingLanguage = false;
    }

    //----------------------------------------------------------------------
    //UI display functions
    public void OpenOptionsUI()
    {
        alternativeTopUI.enabled = false;
        SetChildrenButtonsActive(true);
        animator.SetBool("isOpen", true);
    }

    public void CloseOptionsUI()
    {
        animator.SetBool("isOpen", false);
        SetChildrenButtonsActive(false);
        alternativeTopUI.enabled = true;
    }

}
