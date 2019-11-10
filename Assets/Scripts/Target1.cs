using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vuforia
{

    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class Target1 : MonoBehaviour, ITrackableEventHandler 
    {

        UnityEngine.UI.Image image;
        GameObject btn;


        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES


        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            image = GameObject.Find("FindBottleImage").GetComponent<UnityEngine.UI.Image>();
            btn = GameObject.Find("ConfirmButton");


            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this); //注册追踪事件
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS


        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS


        #region PRIVATE_METHODS

        
        private void OnTrackingFound()
        {
            print("bottle target found");

            image.enabled = false;
            //btn.SetActive(true);
            //targetStatus.Target1_found = true;



            InvokeRepeating("check",0,1);
        }

        void check(){
            print("check");
            bool c = getTime.checkShow();
            if (c)
            {
                btn.SetActive(true);
            }
        }

               
        private void OnTrackingLost()
        {
            print("bottle target lost");

            image.enabled = true;
            btn.SetActive(false);
            //targetStatus.Target1_found = false;

            CancelInvoke();

        }

        #endregion // PRIVATE_METHODS

       
    }
}

