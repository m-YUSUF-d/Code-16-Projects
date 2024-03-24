using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SkyFighter_Menu : MonoBehaviourPunCallbacks
{
    AudioSource source;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject[] sections;
    [SerializeField] private Text playerList;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        SetMusic();
    }



    public void CreateRoom(TMP_InputField input)
    {
        NetworkManager.instance.CreateRoom(input.text);
    }
    public void JoinRoom(TMP_InputField input)
    {
        NetworkManager.instance.JoinRoom(input.text);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        photonView.RPC("UpdatePlayerList", RpcTarget.All);
    }

    public void UpdateName(TMP_InputField name)
    {
        PhotonNetwork.NickName = name.text;
    }
    public override void OnJoinedRoom()
    {
        photonView.RPC("UpdatePlayerList", RpcTarget.All);
    }
    [PunRPC]
    public void UpdatePlayerList()
    {
        playerList.text = "";
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            playerList.text += player.NickName + "\n";
        }
    }
    public void StartGame()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Week 11");
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        UpdatePlayerList();
    }
    public void LeftLobby()
    {
        PhotonNetwork.LeaveRoom();
    }



    public void OpenMenu(int num)
    {
        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].SetActive(false);
        }

        sections[num].SetActive(true);
    }
    public void Sound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    public void SetMusic()
    {
        mixer.SetFloat("Music", Mathf.Log10(slider.value) * 20);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
