using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class MarkerDecider : MonoBehaviour
{
    public GameObject[] steps;
    public bool[] trackedSteps = new bool[3] { false, false, false };
    //privete int currentStep;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getTrackedMarker();
        if (trackedSteps[0] == true || trackedSteps[1] == true || trackedSteps[2] == true)
        {
            Debug.LogFormat("Step1 {0}-- Step2{1}-- Step3 {2}",
                            trackedSteps[0], trackedSteps[1], trackedSteps[2]
                        );
        }
        
    }

    private void getTrackedMarker() 
    {
        for (int i = 0; i < steps.Length; i++)
        {
            if (isTrackingMarker(steps[i]) == true)
            {
                if (trackedSteps[i] == false)
                {
                    //Debug.LogFormat("tracked {0} -- {1}",
                    //    "step", i+1
                    //);
                }
                trackedSteps[i] = true;
            }
            else {
                trackedSteps[i] = false;
            }
        }
        updateTarget();
    }

    private bool isTrackingMarker(GameObject imageTarget)
    {
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }

    private void updateTarget()
    {
        if (trackedSteps[0] == true && trackedSteps[1] == true)
        {
            Debug.LogFormat("only display Step2");
            uneableTarget(steps[0]);
            //steps[0].OnTrackingLost();
        }
        if ((trackedSteps[1] == true && trackedSteps[2] == true) || (trackedSteps[1] == true && trackedSteps[2] == true && trackedSteps[0] == true))
        {
            Debug.LogFormat("only display Step3");
            uneableTarget(steps[1]);
            //steps[1].OnTrackingLost();
        }
    }

    private void uneableTarget(GameObject imageTarget)
    {
        var mTrackableBehaviour = imageTarget.GetComponent<TrackableBehaviour>();

        var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
        var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
        var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }


}
