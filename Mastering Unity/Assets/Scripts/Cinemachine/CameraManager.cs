using System.Collections.Generic;
using Extensions;
using Unity.Cinemachine;
using UnityEngine;

namespace Cinemachine
{
    public class CameraManager : Monosingleton<CameraManager>
    {
        private Dictionary<CameraType, CinemachineCamera> _cameraDictionary = new Dictionary<CameraType, CinemachineCamera>();
        
        private CinemachineCamera _currentCamera;

        void Start()
        {
            SwitchCamera(CameraType.PlayerCamera);
        }

        public void SwitchCamera(CameraType type)
        {
            if (_currentCamera != null)
            {
                _currentCamera.gameObject.SetActive(false);
            }

            if (_cameraDictionary.TryGetValue(type, out var value))
            {
                _currentCamera = value;
                _currentCamera.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Camera of type " + type + " not found in the dictionary.");
            }
        }
    }
}