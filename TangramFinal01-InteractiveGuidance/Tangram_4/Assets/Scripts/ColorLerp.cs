using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorLerp : MonoBehaviour
{
    MeshRenderer ballMeshRenderer;
    [SerializeField] Color myColor;
    private int colorWhite = 0;
    private Color orginalColor;

    // Start is called before the first frame update
    void Start()
    {
        ballMeshRenderer = GetComponent<MeshRenderer>();
        orginalColor = ballMeshRenderer.material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Time());
    }

    IEnumerator Time()
    {
        if (colorWhite == 0)
        {
            ballMeshRenderer.material.color = myColor;
            yield return new WaitForSeconds(0.5f);
            colorWhite = 1;
        }
        else
        {
            ballMeshRenderer.material.color = orginalColor;
            yield return new WaitForSeconds(0.5f);
            colorWhite = 0;
        }
    }
}
