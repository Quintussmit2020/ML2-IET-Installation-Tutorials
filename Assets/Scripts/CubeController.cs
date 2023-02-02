using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
#if !PACKAGE_INSTALLED
using UnityEngine.XR.MagicLeap;
#endif



public class CubeController : MonoBehaviour
{
#if !PACKAGE_INSTALLED
    private MagicLeapInputs mlInputs;
    private MagicLeapInputs.ControllerActions controllerActions;
    public GameObject spawnObject;
    public GameObject spawnLocation;
  

    void Start()
    {
        mlInputs = new MagicLeapInputs();
        mlInputs.Enable();
        controllerActions = new MagicLeapInputs.ControllerActions(mlInputs);
        controllerActions.Bumper.performed += HandleOnTrigger;
        
    }



    private void HandleOnTrigger(InputAction.CallbackContext obj)
    {
        Debug.Log("Button pressed");
      
        GameObject CubeClone = Instantiate(spawnObject, spawnLocation.transform.position, spawnLocation.transform.rotation);

    }
    
#endif
}
