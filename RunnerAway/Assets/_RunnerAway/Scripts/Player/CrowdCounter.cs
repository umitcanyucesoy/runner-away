using System;
using TMPro;
using UnityEngine;

namespace _RunnerAway.Scripts.Player
{
    public class CrowdCounter : MonoBehaviour
    {
        [Header("----- ELEMENTS -----")]
        [SerializeField] private TextMeshPro crowdCounterText;
        [SerializeField] private Transform runnersParent;


        private void Update()
        {
            SetCrowdCounterText();
        }

        private void SetCrowdCounterText()
        {
            crowdCounterText.text = runnersParent.childCount.ToString();
        }
    }
}