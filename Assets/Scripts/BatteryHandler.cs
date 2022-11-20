using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class BatteryHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text batteryText;
    [SerializeField] private TMP_Text statusText;

    private void Update()
    {
        batteryText.text = $"{SystemInfo.batteryLevel*100.0f}%";
        statusText.text = $"{SystemInfo.batteryStatus}";
    }


}
