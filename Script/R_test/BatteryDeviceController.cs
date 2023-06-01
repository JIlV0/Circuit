using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDeviceController : MonoBehaviourPun
{
    public bool isOpen = false;
    [SerializeField] Animator anim;
    public int equipBatCount = 0;

    public void Update()
    {
        anim.SetBool("isOpen", isOpen);
    }

    [PunRPC]
    public void BatCountChange(int c)
    {
        Debug.Log("BatCountChange ȣ��");
        this.photonView.RPC("RpcBatCountChange", RpcTarget.All, c);
    }

    [PunRPC]
    public void RpcBatCountChange(int c)
    {
        Debug.Log("RpcBatCountChange ȣ��");
        this.equipBatCount += c;
        Debug.Log("���� ���͸� �� : " + equipBatCount);
    }


    [PunRPC]
    public void IsOpenChange()
    {
        Debug.Log("IsOpenChange ȣ��");
        this.photonView.RPC("RpcIsOpenChange", RpcTarget.All);
    }

    [PunRPC]
    public void RpcIsOpenChange()
    {
        Debug.Log("RpcIsOpenChange ȣ��");
        isOpen = !isOpen;        
    }
}
