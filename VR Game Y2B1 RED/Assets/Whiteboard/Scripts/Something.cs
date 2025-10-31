using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManagerV2 : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;

        //changed
        [SerializeField]
        public GameObject AIdialogue;

        //changed
        [SerializeField]
        private GameObject objectToToggle;



        [SerializeField]
        List<Step> m_StepList = new List<Step>();

        int m_CurrentStepIndex = 0;

        public void Next()
        {
            // Turn off current step
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);

            // Move to next step
            m_CurrentStepIndex++;

            //changed: checks if the current step No is lower than the total steps
            if (m_CurrentStepIndex < m_StepList.Count)
            {
                // Show the next step
                m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
                m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
                //changed
                StartCoroutine(ToggleObjectAfterDelay());
            }
            else
            {
                // All steps are done -> destroy the whole StepManager GameObject
                Destroy(AIdialogue);

            }
        }

        //changed
        private IEnumerator ToggleObjectAfterDelay()
        {
            objectToToggle.SetActive(false);
            yield return new WaitForSeconds(2f);
            objectToToggle.SetActive(true);
        }
    }
}