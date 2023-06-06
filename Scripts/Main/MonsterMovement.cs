using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private Rigidbody2D monsterRb;

    private float appliedMovementForce = 1500f;
    [SerializeField] private float maxVelocityX = .5f;
    private Vector2 maxVelocityXInVector;
    private Vector2 monsterMassInVector;

    private float stunDuration = 0f;
    private float stunTimer = 0f;

    private bool isStunned = false;

    private void Update()
    {
        if (isStunned)
        {
            stunTimer += Time.deltaTime;

            if (stunTimer >= stunDuration)
            {
                stunTimer -= stunTimer;

                appliedMovementForce = 1500f;

                isStunned = false;
            }
        }
    }

    private void Start()
    {
        SetInitialValues();
    }

    private void FixedUpdate()
    {
        MonsterMovementHandler();
        LimitVelocityOnX();
    }

    private void LimitVelocityOnX()
    {
        if(Mathf.Abs(monsterRb.velocity.x) >= maxVelocityX)
        {
            monsterRb.AddForce(-(monsterRb.velocity + maxVelocityXInVector) * monsterMassInVector, ForceMode2D.Impulse);
        }
    }

    private void MonsterMovementHandler()
    {
            monsterRb.AddForce(-Vector2.right * appliedMovementForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void SetInitialValues()
    {
        maxVelocityXInVector = new Vector3(maxVelocityX, 0f);
        monsterRb = GetComponent<Rigidbody2D>();
        monsterMassInVector = new Vector2(monsterRb.mass, 0f);
    }

    public void Stun(float stunDuration)
    {
        stunTimer -= stunTimer;

        this.stunDuration = stunDuration;

        appliedMovementForce = 0f;

        monsterRb.AddForce(-monsterRb.velocity * monsterMassInVector, ForceMode2D.Impulse);

        isStunned = true;
    }
}
