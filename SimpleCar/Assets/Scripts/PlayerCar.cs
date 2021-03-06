﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCar : BaseCar {

    private UnityAction m_CarHitAction;
    public UnityAction CarHitAction
    { get { return m_CarHitAction; } set { m_CarHitAction = value; } }

    private Vector3 m_vPos;
    public Vector3 PlayerPosition { get { return m_vPos; } set { m_vPos = value;Reset(); } }

    //The main camera is at world zero point, the player car should be in front of it.
    public void Reset()
    {
        Reset(m_vPos);
    }

    private void Start()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        m_vPos = transform.position;
    }

    void Update () {
        UserControl();
    }

    void UserControl()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Steer(5.0f);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Steer(-5.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_CarHitAction!=null)
        {
            m_CarHitAction();
        }
        //Reset();
    }

}
