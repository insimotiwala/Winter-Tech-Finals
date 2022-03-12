using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    public CinemachineVirtualCameraBase[] CamerasSouth;
    public CinemachineVirtualCameraBase[] CamerasWest;
    public CinemachineVirtualCameraBase[] CamerasEast;
    public CinemachineVirtualCameraBase[] CamerasNorth;

    // Start is called before the first frame update
    private void Start()
    {
        DefaultPriority();
        _iSouth = SetCamera(_south, CamerasSouth, _iSouth, out _currentCam);
    }

    private const string _south = "South";
    private const string _west = "West";
    private const string _north = "North";
    private const string _east = "East";
    private string _currentCam;

    private const int _priority = 10;

    private int _iSouth = 0;
    private int _iWest = 0;
    private int _iEast = 0;
    private int _iNorth = 0;

    //set active camera
    private int SetCamera(string camType, CinemachineVirtualCameraBase[] cameras, int currentIndex, out string set)
    {
        DefaultPriority(); //reset all cameras before updating
        if (currentIndex >= cameras.Length) { currentIndex = 0; }
        cameras[currentIndex].Priority = _priority + 1;
        set = camType;
        return currentIndex;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown(_south))
        {
            Debug.Log(_south);
            if (_currentCam == _south) { _iSouth++; }
            _iSouth = SetCamera(_south, CamerasSouth, _iSouth, out _currentCam);
        }
        else if (Input.GetButtonDown(_west))
        {
            Debug.Log(_west);
            if (_currentCam == _west) { _iWest++; }
            _iWest = SetCamera(_west, CamerasWest, _iWest, out _currentCam);
        }
        else if (Input.GetButtonDown(_north))
        {
            Debug.Log(_north);
            if (_currentCam == _north) { _iNorth++; }
            _iNorth = SetCamera(_north, CamerasNorth, _iNorth, out _currentCam);
        }
        else if (Input.GetButtonDown(_east))
        {
            Debug.Log(_east);
            if (_currentCam == _east) { _iEast++; }
            _iEast = SetCamera(_east, CamerasEast, _iEast, out _currentCam);
        }
    }

    //set all cameras to the default priority
    private void DefaultPriority()
    {
        foreach (CinemachineVirtualCameraBase cam in CamerasSouth) { cam.Priority = _priority; }
        foreach (CinemachineVirtualCameraBase cam in CamerasWest) { cam.Priority = _priority; }
        foreach (CinemachineVirtualCameraBase cam in CamerasEast) { cam.Priority = _priority; }
        foreach (CinemachineVirtualCameraBase cam in CamerasNorth) { cam.Priority = _priority; }
    }
}