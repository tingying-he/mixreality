using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockChangeKaya : MonoBehaviour
{
    public Button mButton;
    public Sprite unlock;
    protected bool unLocked;
    
    // Start is called before the first frame update
    void Start()
    {
        unLocked = LockStatus.unlockKaya;
    }

    // Update is called once per frame
    void Update()
    {
        if (unLocked) {
            mButton.image.sprite = unlock;
        }
    }
}
