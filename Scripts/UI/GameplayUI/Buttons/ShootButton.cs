using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerWeapon playerWeapon;

    [SerializeField] private ShootingPoint shootingPointZero;
    [SerializeField] private ShootingPoint shootingPointOne;
    [SerializeField] private ShootingPoint shootingPointTwo;

    private Image buttonImage;

    private Color pressedColor = new Color(1f, 0.68f, 0.29f, 1f);
    private Color notPressedColor = new Color(1f, 0.68f, 0.29f, 0.5f);

    private float barrelZeroTimer = 0f;
    private float barrelOneTimer = 0f;
    private float barrelTwoTimer = 0f;

    private bool barrelZeroCanShoot = true;
    private bool barrelOneCanShoot = false;
    private bool barrelTwoCanShoot = false;

    private bool isPointerDown = false;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    private void Update()
    {
        BarrelZeroRateOfFire();

        BarrelOneRateOfFire();
        
        BarrelTwoRateOfFire();
    }

    private void BarrelZeroRateOfFire()
    {
        if (!barrelZeroCanShoot && isPointerDown)
        {
            barrelZeroTimer += Time.deltaTime;

            if (barrelZeroTimer >= playerWeapon.RateOfFire)
            {
                barrelZeroCanShoot = true;
                barrelZeroTimer -= barrelZeroTimer;
            }
        }

        if (isPointerDown && barrelZeroCanShoot)
        {
            shootingPointZero.Shoot();
            barrelOneCanShoot = true;
            barrelZeroCanShoot = false;
        }
    }

    private void BarrelOneRateOfFire()
    {
        if (barrelOneCanShoot && isPointerDown)
        {
            barrelOneTimer += Time.deltaTime;

            if (barrelOneTimer >= playerWeapon.RateOfFire / playerWeapon.RateOfFireMultiplier)
            {
                if(playerWeapon.BarrelUpgradeLevel > 1)
                {
                    shootingPointOne.Shoot();
                }

                barrelTwoCanShoot = true;
                barrelOneCanShoot = false;
                barrelOneTimer -= barrelOneTimer;
            }
        }
    }

    private void BarrelTwoRateOfFire()
    {
        if (barrelTwoCanShoot && isPointerDown)
        {
            barrelTwoTimer += Time.deltaTime;

            if (barrelTwoTimer >= playerWeapon.RateOfFire / playerWeapon.RateOfFireMultiplier)
            {
                if (playerWeapon.BarrelUpgradeLevel > 2)
                {
                    shootingPointTwo.Shoot();
                }

                barrelTwoCanShoot = false;
                barrelTwoTimer -= barrelTwoTimer;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
	{
		isPointerDown = true;

        buttonImage.color = pressedColor;
    }

	public void OnPointerUp(PointerEventData eventData)
    {
		isPointerDown = false;

        buttonImage.color = notPressedColor;
    }

    private void OnDisable()
    {
        buttonImage.color = notPressedColor;

        isPointerDown = false;
    }
}
