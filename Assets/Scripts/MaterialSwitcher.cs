using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
#if !PACKAGE_INSTALLED
using UnityEngine.XR.MagicLeap;
#endif

public class MaterialSwitcher : MonoBehaviour
{
#if !PACKAGE_INSTALLED
[SerializeField] Material opaqueMaterial = null;
    [SerializeField] Material transparentMaterial = null;

    private bool usingOther = false;
    private MeshRenderer meshRenderer = null;

    private readonly MLPermissions.Callbacks mlPermissionsCallbacks = new MLPermissions.Callbacks();
    private MagicLeapInputs mlInputs;
    private MagicLeapInputs.ControllerActions controllerActions;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        mlPermissionsCallbacks.OnPermissionGranted += MlPermissionsCallbacks_OnPermissionGranted;
        mlPermissionsCallbacks.OnPermissionDenied += MlPermissionsCallbacks_OnPermissionDenied;
        mlPermissionsCallbacks.OnPermissionDeniedAndDontAskAgain += MlPermissionsCallbacks_OnPermissionDenied;
        MLPermissions.RequestPermission(MLPermission.SpatialMapping, mlPermissionsCallbacks);

    }

    private void Start()
    {
        mlInputs = new MagicLeapInputs();
        mlInputs.Enable();
        controllerActions = new MagicLeapInputs.ControllerActions(mlInputs);
        controllerActions.Menu.performed += Menu_performed;
    }


    private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ToggleMaterial();
    }

    public void ToggleMaterial()
    {
       
 
        
       usingOther = !usingOther;

        if (usingOther)
        {
            meshRenderer.material = transparentMaterial;
        }
        else
        {
            meshRenderer.material = opaqueMaterial;
        }
    }

    private void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMaterial();
        } */
    }

    private void MlPermissionsCallbacks_OnPermissionDenied(string permission)
    {
     
    }

    private void MlPermissionsCallbacks_OnPermissionGranted(string permission)
    {
    
    }
#endif
}
