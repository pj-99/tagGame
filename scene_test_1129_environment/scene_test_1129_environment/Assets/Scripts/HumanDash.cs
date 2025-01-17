﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using PhotonTutorial;

public class HumanDash : MonoBehaviourPun
{
    private Rigidbody rb;
    private bool can_dash;
    bool tagging;
    float cnt;
    private Animator m_animator;
    public float dash_speed;
    public int cnt_end;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_animator = gameObject.GetComponent<Animator>();
        tagging = false;
        can_dash = true;
        dash_speed = 0.15f;
        cnt = 0;
        cnt_end = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && (!tagging) && gameObject.GetComponent<SkillController>().sprintPower > 10)
        {
            tagging = true;
            can_dash = false;
            gameObject.GetComponent<SkillController>().sprintPower -= 10;
            m_animator.SetBool("dash", true);
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (tagging)
        {
            if (cnt <= 100) // signal last (and cool down) for 10 frame
            {
                cnt++;
                if(cnt < cnt_end){
                    m_animator.SetBool("dash", false);
                    gameObject.transform.position += transform.forward * dash_speed;
                }
            }
            else
            {
                cnt = 0;
                tagging = false;
                can_dash = true;
            }
        }
    }
}
