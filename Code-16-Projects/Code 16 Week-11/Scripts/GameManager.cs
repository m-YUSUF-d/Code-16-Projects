using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Photon.Pun.Demo.SlotRacer;

public class GameManager : MonoBehaviourPunCallbacks
{
    public int playersInGame;

    public string jet;
    public Transform[] spawnPoints;
    public Fighter[] players;

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        players = new Fighter[PhotonNetwork.PlayerList.Length];
        photonView.RPC("ImInGame", RpcTarget.All);
    }

    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        if (playersInGame == PhotonNetwork.PlayerList.Length)
            SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(jet, spawnPoints[PhotonNetwork.IsMasterClient ? 0 : 1].position, spawnPoints[PhotonNetwork.IsMasterClient ? 0 : 1].rotation);

        Fighter playerScript = playerObj.GetComponent<Fighter>();

        playerScript.photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }





}
