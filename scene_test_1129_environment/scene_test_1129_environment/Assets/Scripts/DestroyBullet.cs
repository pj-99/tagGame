﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DestroyBullet : MonoBehaviourPun
{
    void Start()
    {
        //Destroy(gameObject, 5);
        Invoke(nameof(Destroy), 5);
    }
    /*
    private void OnDestroy()
    {
        photonView.RPC(nameof(DestroyRPC), RpcTarget.All);
    }

    [PunRPC]*/
    public void Destroy()
    {
        if (!photonView.IsMine) return;
        PhotonNetwork.Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if(!photonView.IsMine) return;
        print("bullethit");
        PhotonNetwork.Destroy(gameObject);
    }
}
