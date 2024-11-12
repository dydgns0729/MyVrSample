using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    public class AnimateHandOnInput : MonoBehaviour
    {
        #region Variables

        Animator handAnimator;

        //인풋 입력값 처리
        public InputActionProperty pinchAnimation;
        public InputActionProperty gripAnimation;

        #endregion

        void Start()
        {
            //참조
            handAnimator = GetComponent<Animator>();
        }
        void Update()
        {
            float triggerValue = pinchAnimation.action.ReadValue<float>();
            float gripValue = gripAnimation.action.ReadValue<float>();
            //Debug.Log($"triggerValue : {triggerValue}");
            handAnimator.SetFloat("Trigger", triggerValue);
            handAnimator.SetFloat("Grip", gripValue);
        }
    }
}