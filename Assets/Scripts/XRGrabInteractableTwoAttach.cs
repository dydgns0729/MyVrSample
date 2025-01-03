using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// 두개의 Attach Point 구현
    /// </summary>
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        #region Variablse
        public Transform leftAttachTransform;
        public Transform rightAttachTransform;
        #endregion

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            //두개의 Attach Point를 잡는 손에 따라 구분해서 적용
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            base.OnSelectEntering(args);
        }

        protected override void OnSelectExiting(SelectExitEventArgs args)
        {
            // 오브젝트를 놓을 때 BoxCollider 다시 활성화
            this.gameObject.GetComponent<BoxCollider>().enabled = true;

            base.OnSelectExiting(args);
        }

        /*protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            //두개의 Attach Point를 잡는 손에 따라 구분해서 적용
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTransform;
            }

            base.OnSelectEntered(args);
        }*/
    }
}