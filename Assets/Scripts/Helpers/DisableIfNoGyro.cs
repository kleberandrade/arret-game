using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfNoGyro : MonoBehaviour {

    private void Awake()
    {
        if (!Input.gyro.enabled)
        {
            gameObject.SetActive(false);
        }
    }
}
