using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour
{
    public Button mButton;
    public Sprite play;
    public Sprite pause;
    protected bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        // switch = false;
        mButton.onClick.AddListener
        (
            delegate () { SetPause(); }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPause() {
        if (flag) {
            mButton.image.sprite = play;
            flag = false;
        } else {
            mButton.image.sprite = pause;
            flag = true;
        }
    }
}
