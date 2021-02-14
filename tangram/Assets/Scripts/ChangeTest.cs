using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTest : MonoBehaviour
{
    public Button mButton;
    protected bool switchFlag;
    public Sprite hiphop;
    public Sprite michelle;

    // Start is called before the first frame update
    void Start()
    {
        // switchFlag = LockTest.unlock;
        
        // hiphop = Resources.Load("Resources/images/hiphop", typeof(Sprite)) as Sprite;
        // michelle = Resources.Load("Resources/images/michelle", typeof(Sprite)) as Sprite;
    }

    void Update() {
        if (!switchFlag) {
            mButton.image.sprite = hiphop;
            // switchFlag = true;
            Debug.Log("111111111");
        } else {
            // mButton.image.overrideSprite = michelle;
            // switchFlag = true;
        }
    }

    // Update is called once per frame
    // void OnClick()
    // {
    //     if (switchFlag) {
    //         mButton.image.overrideSprite = hiphop;
    //         switchFlag = false;
    //     } else {
    //         // mButton.image.overrideSprite = michelle;
    //         // switchFlag = true;
    //     }
    // }
}
