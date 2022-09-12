using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomTextScript : MonoBehaviour
{
    [Header("text that you want to display!")]
    [SerializeField] 
    private string textToAdd;
    [Header("modified text component (only replace if you know what you are doing!)")]
    [SerializeField]
    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        //set the text
        text.SetText(textToAdd);
    }

}
