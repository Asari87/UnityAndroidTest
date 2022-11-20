using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class GyroPanel : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] private Scrollbar xBar;
    [SerializeField] private Scrollbar yBar;
    [SerializeField] private Scrollbar zBar;

    private void OnEnable()
    {
        InputSystem.EnableDevice(Gyroscope.current);
        if (Gyroscope.current.enabled)
        {
            title.color = Color.green;
            Debug.Log("Gyro is enabled");
        }

    }

    private void OnDisable()
    {
        InputSystem.DisableDevice(Gyroscope.current);
        if (!Gyroscope.current.enabled)
            Debug.Log("Gyro is disabled");
    }

    void Update()
    {

        if (Gyroscope.current.enabled)
        {
            Vector3Control accData = Gyroscope.current.angularVelocity;
            Vector3 data = accData.ReadValue();
            xBar.value = (data.x + 1) / 2.0f;
            yBar.value = (data.y + 1) / 2.0f;
            zBar.value = (data.z + 1) / 2.0f;

        }

    }
}
