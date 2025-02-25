using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnSwingSwayed;
    public event Action OnLaunchProjectile;
    public event Action OnReloadCatapult;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            OnSwingSwayed?.Invoke();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnLaunchProjectile?.Invoke();

        if(Input.GetKeyDown(KeyCode.Mouse1))
            OnReloadCatapult?.Invoke();
    }
}