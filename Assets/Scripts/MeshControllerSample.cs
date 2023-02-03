using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
#if !PACKAGE_INSTALLED
using UnityEngine.XR.MagicLeap;
#endif


public class MeshControllerSample : MonoBehaviour
{
#if !PACKAGE_INSTALLED
    
    public MeshingSubsystemComponent meshingSubsystemComponent;
    private readonly MLPermissions.Callbacks mlPermissionsCallbacks = new MLPermissions.Callbacks();
   
   
   

    private void Awake()
    {
        mlPermissionsCallbacks.OnPermissionGranted += MlPermissionsCallbacks_OnPermissionGranted;
        mlPermissionsCallbacks.OnPermissionDenied += MlPermissionsCallbacks_OnPermissionDenied;
        mlPermissionsCallbacks.OnPermissionDeniedAndDontAskAgain += MlPermissionsCallbacks_OnPermissionDenied;
        MLPermissions.RequestPermission(MLPermission.SpatialMapping, mlPermissionsCallbacks);
        meshingSubsystemComponent = GetComponent<MeshingSubsystemComponent>();
    }

    void Start()
    {

    }



    private void MlPermissionsCallbacks_OnPermissionDenied(string permission)
    {
        meshingSubsystemComponent.enabled = false;
    }

    private void MlPermissionsCallbacks_OnPermissionGranted(string permission)
    {
        meshingSubsystemComponent.enabled = true;

    }
#endif
}
