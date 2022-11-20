
using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

using Accelerometer = UnityEngine.InputSystem.Gyroscope;

public class AccelerometerPanel : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] private Scrollbar xBar;
    [SerializeField] private Scrollbar yBar;
    [SerializeField] private Scrollbar zBar;

    private void OnEnable()
    {
        InputSystem.EnableDevice(Accelerometer.current);
        if (Accelerometer.current.enabled)
        {
            title.color = Color.green;
            Debug.Log("Accelerometer is enabled");
        }
            
    }

    private void OnDisable()
    {
        InputSystem.EnableDevice(Accelerometer.current);
        if (!Accelerometer.current.enabled)
            Debug.Log("Accelerometer is disabled");
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Accelerometer.current.enabled)
        {
            Vector3Control accData = Accelerometer.current.angularVelocity;
            Vector3 data = accData.ReadValue();
            xBar.value = (data.x + 1) / 2.0f;
            yBar.value = (data.y + 1) / 2.0f;
            zBar.value = (data.z + 1) / 2.0f;
            
        }
            
    }
}
