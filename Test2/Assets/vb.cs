using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonTest : MonoBehaviour {  //实现IVirtualButtonEventHandler接口，该接口包含OnButtonPressed和OnButtonReleased两个方法

    private GameObject cube;
    private GameObject sphere;

    // Use this for initialization
    void Start () {

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();   //获取VirtualButton Behaviour组件
        for (int i = 0; i < vbs.Length; ++i) {     //遍历所有组件
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbs[i].RegisterOnButtonReleased(OnButtonReleased);    //对该脚本进行注册
        }//

        cube = transform.Find("Cube").gameObject;
        // sphere = transform.Find ("Sphere").gameObject;

        cube.SetActive (false);
        // sphere.SetActive (false);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        switch (vb.VirtualButtonName) {
        case "TestButton":
            cube.SetActive (true);
            break;
        case "showSphere":
            // sphere.SetActive (true);
            break;
        }
        Debug.Log ("OnButtonPressed: " + vb.VirtualButtonName);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        switch (vb.VirtualButtonName) {
        case "TestButton":
            cube.SetActive (false);
            break;
        case"showSphere":
            // sphere.SetActive (false);
            break;
        }
        Debug.Log ("OnButtonReleased: " + vb.VirtualButtonName);
    }
}