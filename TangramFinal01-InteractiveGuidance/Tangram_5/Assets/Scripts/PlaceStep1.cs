using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceStep1 : MonoBehaviour
{
    public GameObject step1;
    public GameObject stepAR;
    private PlayOnNextTracked player;

    private Vector3 step1ScreenPoint;
    private Renderer[] step1Renderer;
    private bool matched = false;
    private int totalTime = 3;

    private bool firtTracked = false;
    private bool firstMatched = false;



    // Start is called before the first frame update
    void Start()
    {
        //step1.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));

        Debug.LogFormat("ScreenWidth {0}-- ScreenHeight {1}",
                Screen.width / 2, Screen.height / 2
            );

        player = GetComponentInChildren<PlayOnNextTracked>();
        player.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrackingMarker(step1) == true && !matched)
        {
            var mTrackableBehaviour = step1.GetComponent<TrackableBehaviour>();
            step1Renderer = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);

            step1Renderer[0].enabled = false;

            if (firtTracked == false)
            {
                player.PlayOnAppear();
                firtTracked = true;
            }
           
        }
        else
        {
            
        }


        step1ScreenPoint = Camera.main.WorldToScreenPoint(step1.transform.position);

        var disX = System.Math.Abs(step1ScreenPoint.x - Screen.width / 2);
        var disY = System.Math.Abs(step1ScreenPoint.y - Screen.height / 2);
        if (disX <= 4 && disY <= 4)
        {
            Debug.Log("Get it");
            Destroy(stepAR);
            step1Renderer[0].enabled = true;
            step1Renderer[1].enabled = false;
            matched = true;
            StartCoroutine(Time());

            if (firstMatched == false)
            {
                player.PlayOnMatch();
                firstMatched = true;
            }
        }

        if (totalTime <= 0)
        {
            Debug.Log("sceneName to load: ");
            SceneManager.LoadScene("Step1");
        }
    }

    private bool isTrackingMarker(GameObject imageTarget)
    {
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }

    IEnumerator Time()
    {
        while (totalTime >= 0)
        {
            yield return new WaitForSeconds(1);
            totalTime--;
            Debug.LogFormat("remaining time: {0}", totalTime);
        }
    }
}
