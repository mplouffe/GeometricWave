using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBoost : MonoBehaviour
{
    public InputAction boostAction;

    public float speedBoost;
    public float boostDuration;
    public float boostCooldown;

    private bool boosting = false;
    private bool boostOnCooldown = false;

    private float lastBoost;

    private Slider boostCooldownSlider;

    private Rigidbody rigidBody;

    void Start()
    {
        boostCooldownSlider = GameObject.FindGameObjectWithTag("boostUI").GetComponent<Slider>();
        boostCooldownSlider.value = 10;
    }

    private void OnEnable()
    {
        rigidBody = GetComponent<Rigidbody>();
        boostAction.Enable();
    }

    private void OnDisable()
    {
        boostAction.Disable();
    }

    void Update()
    {
        var lastBoostInterval = Time.time - lastBoost;

        if (boostOnCooldown)
        {
            if (lastBoostInterval < boostCooldown)
            {
                var delta = (lastBoostInterval / boostCooldown) * 10;
                boostCooldownSlider.value = delta;
            }
            else
            {
                boostCooldownSlider.value = 10;
                boostOnCooldown = false;
            }
        }

        if (boosting)
        {
            if (lastBoostInterval < boostDuration)
            {
                Vector3 boostForce = gameObject.transform.up * speedBoost;
                rigidBody.AddForce(boostForce);
            }
            else
            {
                boosting = false;
            }
        }

        if (!boosting && !boostOnCooldown)
        {
            if (boostAction.triggered)
            {
                lastBoost = Time.time;
                boostOnCooldown = true;
                boosting = true;
                boostCooldownSlider.value = 0;
            }
        }
    }
}
