
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
 
public class VirtualBtnController : MonoBehaviour
{
 
    public GameObject virtualButton;
    public GameObject zombie;

private Animator     animator;
    public bool switchStage;
    public int flag;
 
    // Use this for initialization
    void Start()
    {
        // virtualButton = GameObject.Find ("actionButton");
    zombie = GameObject.Find ("zombie");
    // virtualButton.GetComponent<VirtualButtonAbstractBehaviour> ().RegisterEventHandler (this);

    animator = zombie.GetComponent<Animator>();

     virtualButton = GameObject.Find("VirtualButton");
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    public void changeAnimation(){
        // if(switchStage)
        // {
        //     switchStage = false;
        //     animator.SetBool("SwitchStage", false);    
        // }else 
        // {
        //     switchStage = true;
        //     animator.SetBool("SwitchStage", true);    
        // }
    }
 
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        // changeAnimation();
        
    Debug.Log ("Button Pressed"+switchStage);
    // zombie.GetComponent<Animator> ().enabled = false;
         // animator.SetBool("SwitchStage", true);   

flag = flag +1;
flag = flag % 3;
          animator.SetInteger("flag",flag);

        
    }
 
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        // switchStage = false;
       // Debug.Log ("Button Released"+switchStage);
    // zombie.GetComponent<Animator> ().enabled = true;
        
        //animator.SetBool("SwitchStage", false);  

        
    }

    void Update()
    {
    }


}

