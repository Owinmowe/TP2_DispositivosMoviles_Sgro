using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpinningTop))]
public class PlayerInput : MonoBehaviour
{
    SpinningTop top;
    private void Awake()
    {
        top = GetComponent<SpinningTop>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        Vector3 pushForce;
#if UNITY_EDITOR
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        pushForce = new Vector3(horizontal, 0, vertical);
#elif UNITY_ANDROID
        pushForce = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
        top.Move(pushForce);
    }
}
