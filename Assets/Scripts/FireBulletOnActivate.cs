using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// 권총 총알 발사
    /// </summary>
    public class FireBulletOnActivate : MonoBehaviour
    {
        #region Variables
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed = 20f;
        public float hapticAmplitude = 0.5f; // 진동 강도 (0.0 ~ 1.0)
        public float hapticDuration = 0.2f; // 진동 지속 시간 (초)
        #endregion

        private void Start()
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(Fire);
        }

        void Fire(ActivateEventArgs args)
        {
            Debug.Log(args.interactorObject.transform.name);
            HapticImpulsePlayer controller = args.interactorObject.transform.GetComponentInParent<HapticImpulsePlayer>();
            if (controller)
            {
                controller.SendHapticImpulse(hapticAmplitude, hapticDuration);
            }
            else
            {
                Debug.Log("디바이스 못찾음");
            }

            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletGo.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
            Destroy(bulletGo, 5f);


        }
    }
}