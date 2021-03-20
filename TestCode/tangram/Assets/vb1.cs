using Vuforia;
using System.Collections.Generic;
using UnityEngine;

public class VirtualButtonTest2 : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject virButton;
    private GameObject cube;


    // Use this for initialization
    void Start () {

        virButton.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
        cube = transform.Find ("Cube").gameObject;
        cube.SetActive (false);

    }
    // Update is called once per frame
    public void OnButtonPressed (VirtualButtonBehaviour vb){
        switch (vb.VirtualButtonName) {
        case "TestButton":

            cube.SetActive (true);
            break;
        default:
            break;
        }
        Debug.Log ("OnButtonPressed");
    }
    public void OnButtonReleased (VirtualButtonBehaviour vb){
        cube.SetActive (false);
        Debug.Log ("OnButtonReleased");
    }
}