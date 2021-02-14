using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockChangeMary : MonoBehaviour
{
    public Button mButton;
    public Sprite unlock;
    protected bool unLocked;

    // Start is called before the first frame update
    void Start()
    {
        unLocked = LockStatus.unlockMary;
    }

    // Update is called once per frame
    void Update()
    {
        if (unLocked) {
            mButton.image.sprite = unlock;
        }
    }
}
