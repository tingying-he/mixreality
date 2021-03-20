using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StepManager : MonoBehaviour
{

    public GameObject baseStep;
    public GameObject nextStep;
    public GameObject baseAR;

    private bool baseStepTracked = false;
    private bool nextStepTracked = false;

    private int totalTime = 3; //3
    private bool startCountDown = false;
    private Renderer[] baseStepRenderer;
    private Renderer[] nextStepRenderer;

    private PlayOnNextTracked player;
    private bool firtTracked = false;
    private bool firstMatched = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInChildren<PlayOnNextTracked>();
        player.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        getTrackedMarker();

        if (totalTime <= 0)
        {
            Debug.Log("sceneName to load: " + "Step2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       

    }

    IEnumerator Time()
    {
        while (totalTime >= 0 && startCountDown)
        {
            yield return new WaitForSeconds(1);
            totalTime--;
            Debug.LogFormat("remaining time: {0}", totalTime);
        }
    }

    private void getTrackedMarker()
    {
        if (isTrackingMarker(baseStep) == true)
        {
            var mTrackableBehaviour = baseStep.GetComponent<TrackableBehaviour>();
            baseStepRenderer = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);

            baseStepTracked = true;
        }
            
        else
            baseStepTracked = false;

        if (isTrackingMarker(nextStep) == true)
        {
            nextStepTracked = true;

            var mTrackableBehaviour = nextStep.GetComponent<TrackableBehaviour>();
            nextStepRenderer = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);

            nextStepRenderer[0].enabled = false;

            if (firtTracked == false)
            {
                player.PlayOnAppear();
                firtTracked = true;
            }
        }  
        else
            nextStepTracked = false;

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
        if (baseStepTracked == true && nextStepTracked == true)
        {
            float distance = Vector3.Distance(baseAR.transform.position, nextStep.transform.position);

            if (distance <= 0.01)
            {
                Debug.LogFormat("MATCHED"
                        );
                if (firstMatched == false)
                {
                    player.PlayOnMatch();
                    firstMatched = true;
                }

                baseStepRenderer[0].enabled = false;

                nextStepRenderer[0].enabled = true;
                nextStepRenderer[1].enabled = false;

                if(startCountDown == false)
                    totalTime = 3;

                startCountDown = true;
                StartCoroutine(Time());
            }
            else
            {
                baseStepRenderer[0].enabled = true;
                //eableBaseAR(baseStep);

                startCountDown = false;
                nextStepRenderer[0].enabled = false;
                nextStepRenderer[1].enabled = true;
            }
        }
    }

    private void uneableBaseAR(GameObject imageTarget)
    {
        var mTrackableBehaviour = imageTarget.GetComponent<TrackableBehaviour>();

        var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;
    }

    private void eableBaseAR(GameObject imageTarget)
    {
        var mTrackableBehaviour = imageTarget.GetComponent<TrackableBehaviour>();

        var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;
    }

}
