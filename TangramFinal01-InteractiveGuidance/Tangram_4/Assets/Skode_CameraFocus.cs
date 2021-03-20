using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;
 
/*可直接挂在摄像头上
 * 当识别不清晰时，点击Skode_CameraSet自动对焦
 */
public class Skode_CameraFocus : MonoBehaviour
{
    void Update()
    {
        Skode_CameraSet();
    }
 
    public void Skode_CameraSet()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
    }

}
