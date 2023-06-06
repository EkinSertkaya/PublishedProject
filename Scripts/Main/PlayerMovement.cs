using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TurnClockwiseButton turnClockwiseButton;
    [SerializeField] private TurnCounterClockwiseButton turnCounterClockwiseButton;

    private Quaternion rotation;

    private Vector3 rotationVector = Vector3.zero;

    private float zRotateAmount = 1f;

    private float rotationSpeed = 10f;
    public float RotationSpeed { get { return rotationSpeed; } }

    private float upgradedSpeedAmount = 10f;
    private float maxSpeedAmount = 60f;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        JoyStickControls();
    }

    private void JoyStickControls()
    {
        if (turnClockwiseButton.IsPointerDown)
        {
            rotationVector.z += zRotateAmount * Time.deltaTime * rotationSpeed;
            rotation.eulerAngles = rotationVector;
            transform.localRotation = rotation;
        }
        else if (turnCounterClockwiseButton.IsPointerDown)
        {
            rotationVector.z -= zRotateAmount * Time.deltaTime * rotationSpeed;
            rotation.eulerAngles = rotationVector;
            transform.localRotation = rotation;
        }
    }

    private void Setup()
    {
        rotation.eulerAngles = Vector3.zero;
    }

    public void UpgradeTurnSpeed()
    {
        rotationSpeed += upgradedSpeedAmount;

        if (rotationSpeed > maxSpeedAmount)
        {
            rotationSpeed = maxSpeedAmount;
        }
    }

    public void ResetWeaponRotation()
    {
        rotationVector.z = 0;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
