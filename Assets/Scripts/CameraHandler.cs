using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text foundText;
    [SerializeField] private TMP_Text status;
    [SerializeField] private RawImage screenFront;
    private WebCamTexture webcamTexture;
    private bool camReady = false;
    WebCamDevice[] devices;
    int cameraIndex = 0;
    private bool camActivation = false;
    void Start()
    {

        InitializeCamera();

    }
    public void ManualInit()
    {
        InitializeCamera();
    }

    private void InitializeCamera()
    {
        devices = WebCamTexture.devices;
        foundText.text = devices.Length.ToString();
        if (devices.Length > 0)
        {
            AssignCamera(devices[cameraIndex++].name);
        }
    }

    private void AssignCamera(string name)
    {
        webcamTexture = new WebCamTexture();
        webcamTexture.deviceName = name;
        screenFront.texture = webcamTexture;


        camReady = webcamTexture.isReadable;
    }

    private void Update()
    {
        if(camReady)
            status.text = webcamTexture.isPlaying.ToString();
        else
            status.text = $"Not Readable";
    }

    public void ToggleCamActivation()
    {
        camActivation = !camActivation;
        TogglePlay(camActivation);
    }

    private void TogglePlay(bool activate)
    {
        if (!camReady) return;

        if (webcamTexture.isPlaying && activate) return;
        if (!webcamTexture.isPlaying && !activate) return;

        if (activate)
            webcamTexture.Play();

        else
            webcamTexture.Stop();
        
        
    }

    public void SwitchCamera()
    {
        if (devices.Length < 2) return;

        TogglePlay(false);

        AssignCamera(devices[cameraIndex++%devices.Length].name);

        TogglePlay(true);


    }
}
