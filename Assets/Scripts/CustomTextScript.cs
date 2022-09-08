using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomTextScript : MonoBehaviour
{
    [SerializeField] 
    private string textToAdd;
    [SerializeField]
    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponentInChildren<TextMeshProUGUI>().SetText(textToAdd);
        text.SetText(textToAdd);
    }

}
