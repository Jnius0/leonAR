using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [Header("The length of this list must match the number of images in Reference Image Library and the names must be identical (case sensitive!)")]
    [SerializeField]
    private GameObject[] placeablePrefabs; //<<< list of prefabs that have to be placed in the scene

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>(); //<<< dictionnary to link the different images and prefabs by their names
    private ARTrackedImageManager trackedImageManager; //<<< manager to detect 2D images

    private void Awake()
    {
        //initialize the manager
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        //instantiate the prefabs on load but disables them to prepare the scene
        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
            newPrefab.SetActive(false);
        }
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
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            //spawnedPrefabs[trackedImage.name].SetActive(false);
            Destroy(spawnedPrefabs[trackedImage.name]);
        }
    }

    //updates the positions and rotations of prefabs depending on the given detected image
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        //link between the tracked image in parameters and the prefabs is made thanks to their name
        string name = trackedImage.referenceImage.name;
        GameObject prefab = spawnedPrefabs[name];

        if (trackedImage.trackingState != TrackingState.Tracking)
        {
            prefab.SetActive(false);
            return;
        }


        Vector3 position = trackedImage.transform.position;
        Quaternion rotation = trackedImage.transform.rotation;
        prefab.transform.position = position;
        prefab.transform.rotation = rotation;
        prefab.SetActive(true);
    }
}
