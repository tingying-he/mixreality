using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBackClick : MonoBehaviour
{
    public Button button1;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button1.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        Application.LoadLevel(0);
    }
}
