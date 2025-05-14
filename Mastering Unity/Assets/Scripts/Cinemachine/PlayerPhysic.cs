using System;
using UnityEngine;

namespace Cinemachine
{
    public class PlayerPhysic : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BossCamera"))
            {
                CameraManager.Instance.SwitchCamera(CameraType.BossCamera);
            }
        }
    }
}