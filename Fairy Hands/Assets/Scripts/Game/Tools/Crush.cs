﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Crush : MonoBehaviour
{
    public float Magnitude = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            var velocityEstimator = GetComponentInParent<VelocityEstimator>();
            if (velocityEstimator && velocityEstimator.GetVelocityEstimate().magnitude > Magnitude)
            {
                var modifier = other.gameObject.GetComponent<Modifier>();
                if (modifier)
                    modifier.ApplyModification();
            }
        }
    }
}
