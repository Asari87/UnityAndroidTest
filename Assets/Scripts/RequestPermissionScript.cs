
using UnityEngine;
using UnityEngine.Android;

public class RequestPermissionScript : MonoBehaviour
{
    internal void PermissionCallbacks_PermissionDeniedAndDontAskAgain(string permissionName)
    {
        Debug.Log($"Unity:{permissionName} PermissionDeniedAndDontAskAgain");
    }

    internal void PermissionCallbacks_PermissionGranted(string permissionName)
    {
        Debug.Log($"Unity:{permissionName} PermissionCallbacks_PermissionGranted");
        FindObjectOfType<CameraHandler>().ManualInit();
    }

    internal void PermissionCallbacks_PermissionDenied(string permissionName)
    {
        Debug.Log($"Unity:{permissionName} PermissionCallbacks_PermissionDenied");
    }

    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // The user authorized use of the microphone.
            Debug.Log($"Unity: Permission Granted");
        }
        else
        {
            bool useCallbacks = true;
            if (!useCallbacks)
            {
                Debug.Log($"Unity: Requestubg Permission");

                // We do not have permission to use the camera.
                // Ask for permission or proceed without the functionality enabled.
                Permission.RequestUserPermission(Permission.Camera);
            }
            else
            {
                Debug.Log($"Unity: Requestubg Permission with callback");

                var callbacks = new PermissionCallbacks();
                callbacks.PermissionDenied += PermissionCallbacks_PermissionDenied;
                callbacks.PermissionGranted += PermissionCallbacks_PermissionGranted;
                callbacks.PermissionDeniedAndDontAskAgain += PermissionCallbacks_PermissionDeniedAndDontAskAgain;
                Permission.RequestUserPermission(Permission.Camera, callbacks);
            }
        }
    }
}