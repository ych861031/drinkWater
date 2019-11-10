using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vuforia
{

    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class Target2 : MonoBehaviour, ITrackableEventHandler 
    {

        GameObject CanOBJ;


        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES


        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            CanOBJ = GameObject.Find("CanOBJ");
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
            print("飲水機 target found");
            CanOBJ.SetActive(true);
            //targetStatus.Target2_found = true;
            if (getTime.checkShowDrinkingFountain())
            {
                print("in");
                getTime.setTimeDrinkingFountain();
                UserInfo.SetDrinkingFountain();

            }
        }

               
        private void OnTrackingLost()
        {
            print("飲水機 target lost");
            CanOBJ.SetActive(false);
            //targetStatus.Target2_found = false;

        }

        #endregion // PRIVATE_METHODS


    }
}

