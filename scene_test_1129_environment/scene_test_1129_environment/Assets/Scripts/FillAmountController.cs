﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmountController : MonoBehaviourPun
{
    // GAMEOBJECT
    // private Image skill1CoolDown;
    // private Image skill2CoolDown;
    // private Image skill3CoolDown;
    // private Image skill4CoolDown;
    // private Image sprintPower;
    // private SkillController skillController;

    // public GameObject skill1CoolDown;
    // public GameObject skill2CoolDown;
    // public GameObject skill3CoolDown;
    // public GameObject skill4CoolDown;
    // public GameObject sprintPower;
    
    private Image skill1CoolDownImage;
    private Image skill2CoolDownImage;
    private Image skill_pickup_image;

    private Image skill3CoolDownImage;
    private Image skill4CoolDownImage;
    private Image sprintPowerImage;
    // public GameObject player;
    private SkillController skillController;
    private PhotonView photonView;

    public Sprite charactor_skill_sprite;

    public Sprite[] pickup_skill_sprite;


    public Image[] bulletPicked = new Image[6];
    // public GameObject player;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(!photonView.IsMine){
            return;
        }
        Image skill1_Image = GameObject.Find("SkillUI/SkillCoolDown/Skill1").GetComponent<Image>();
        skill_pickup_image = GameObject.Find("SkillUI/SkillCoolDown/Skill2").GetComponent<Image>();
        skill1CoolDownImage = GameObject.Find("SkillUI/SkillCoolDown/Skill1/Skill1CoolDown").GetComponent<Image>();
        skill2CoolDownImage = GameObject.Find("SkillUI/SkillCoolDown/Skill2/Skill2CoolDown").GetComponent<Image>();
        //skill3CoolDownImage = GameObject.Find("SkillUI/SkillCoolDown/Skill1/Skill1CoolDown").GetComponent<Image>();
        //skill4CoolDownImage = GameObject.Find("SkillUI/SkillCoolDown/Skill1/Skill1CoolDown").GetComponent<Image>();
        //sprintPowerImage = GameObject.Find("SkillAndSprintCanvas/SprintBar/SprintPower").GetComponent<Image>();
        skillController = gameObject.GetComponent<SkillController>();
        
     //   sprintPowerImage = GameObject.Find("SkillAndSprintCanvas/bgArtboard 17").GetComponent<Image>();
    
        bulletPicked[0] = GameObject.Find("SkillUI/SkillCoolDown/bullet1").GetComponent<Image>();
        bulletPicked[1] = GameObject.Find("SkillUI/SkillCoolDown/bullet2").GetComponent<Image>();
        bulletPicked[2] = GameObject.Find("SkillUI/SkillCoolDown/bullet3").GetComponent<Image>();
        bulletPicked[3] = GameObject.Find("SkillUI/SkillCoolDown/bullet4").GetComponent<Image>();
        bulletPicked[4] = GameObject.Find("SkillUI/SkillCoolDown/bullet5").GetComponent<Image>();

        skill_pickup_image.sprite = pickup_skill_sprite[0];
        skill1_Image.sprite = charactor_skill_sprite;
        RefreshBulletNum(0);
    }

    void Update()
    {
        if (!photonView.IsMine) return;
        skill1CoolDownImage.fillAmount = (1.0f) * skillController.skill1Cooldown / skillController.skill1Speed;
        skill2CoolDownImage.fillAmount = (1.0f) * skillController.skill2Cooldown / skillController.skill2Speed;
        //skill3CoolDownImage.fillAmount = (1.0f) * skillController.skill3Cooldown / skillController.skill3Speed;
        //skill4CoolDownImage.fillAmount = (1.0f) * skillController.skill4Cooldown / skillController.skill4Speed;
       // sprintPowerImage.fillAmount = (1.0f) * skillController.sprintPower / skillController.sprintMaxPower;
        
    }


    public void PickUpSkill(int i)
    {
        if(!photonView.IsMine){
            return;
        }
        skill_pickup_image.sprite = pickup_skill_sprite[i+1];
    }
    public void RefreshBulletNum(int num) {
        if (!photonView.IsMine) return;
        for(int i = 0; i < 5; i++) {
            if (num == 0)
            {
                skill_pickup_image.sprite = pickup_skill_sprite[0];
            }
            if(i <= (num - 1)){
                bulletPicked[i].enabled = true;
            } else {
                bulletPicked[i].enabled = false;
            }
        }
    }
}