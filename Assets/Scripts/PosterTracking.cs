using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PosterTracking : MonoBehaviour
{
    //---------------------------------------------------------------------------------------------------------------------------------
    //serialized dictionary handling
    [Header("The length of this list must match the number of images in Reference Image Library, first string must be the name of the picture in the library, second the name of the scene to transition to, the third the link to the poster page on the website.")]
    [SerializeField]
    TripleStringDictionary scenes = null;//<<< dictionnary to map poster names to their scene and link

    //using open source code from github: https://github.com/azixMcAze/Unity-SerializableDictionary
    public IDictionary<string, DoubleString> TripleStringDictionary
    {
        get { return scenes; }
        set { scenes.CopyFrom(value); }
    }
    //-------------------------------------------------------------------------------------------------------------------------------------

    [Header("UI to enable and disable whenever a poster is detected.")]
    [SerializeField]
    private GameObject detectionUI;
    [Header("button handling script to give the scene names to.")]
    [SerializeField]
    private GeneralButtonsScript buttonsScript;
    [Header("Poster detection text.")]
    [SerializeField]
    private TextMeshProUGUI text;

    private ARTrackedImageManager trackedImageManager; //<<< manager to detect 2D images

    private void Awake()
    {
        //initialize the manager
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        detectionUI.SetActive(false);
        text.enabled = false;
    }

    //add the ImageChanged function to the trackedImagesChanges event of the manager to add our functionalities
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    //updates the display of prefabs depending on the images detected by calling the UpdateImage function
    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            LoseTracking();
        }
    }

    //updates the positions and rotations of prefabs depending on the given detected image
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage.trackingState != TrackingState.Tracking)
        {
            LoseTracking();
            return;
        }

        //link between the tracked image in parameters and the prefabs is made thanks to their name
        string name = trackedImage.referenceImage.name;
        string scene = scenes[name].scene;
        string link = scenes[name].link;

        buttonsScript.detectedPosterScene = scene;
        buttonsScript.detectedPosterLink = link;
        detectionUI.SetActive(true);
        text.enabled = true;
    }

    //updates all needed elements when tracking is lost
    private void LoseTracking()
    {
        text.enabled = false;
        detectionUI.SetActive(false);
        buttonsScript.detectedPosterScene = "";
        buttonsScript.detectedPosterLink = "";
    }
}
