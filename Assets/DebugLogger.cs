using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class DebugLogger : MonoBehaviour
{
    [SerializeField] TMP_Text debug;

    private void Start()
    {
        debug.text = $"{Application.platform}\n{SystemInfo.operatingSystem}";
    }
}
