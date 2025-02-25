using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    PlayerMovement moveScript;
    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    bool canDash = true;

    private void Start()
    {
        moveScript = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        moveScript.isDashing = true;
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            moveScript.MovePlayer(moveScript.moveDirection * dashSpeed * Time.deltaTime);
            yield return null;
        }

        moveScript.isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
