using UnityEngine;
using UnityEngine.XR;

public class VRManager : MonoBehaviour
{
    public GameObject vrRig;
    public GameObject desktopRig;
    private bool isVRActive;

    void Start()
    {
        isVRActive = XRSettings.isDeviceActive;
        SwitchControlMode(isVRActive);
    }

    void Update()
    {
        if (isVRActive != XRSettings.isDeviceActive)
        {
            isVRActive = XRSettings.isDeviceActive;
            SwitchControlMode(isVRActive);
        }
    }

    void SwitchControlMode(bool enableVR)
    {
        vrRig.SetActive(enableVR);
        desktopRig.SetActive(!enableVR);
    }
}
