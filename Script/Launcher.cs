using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;
    public int stageNum = 0;

    [SerializeField] private byte maxPlayersPerRoom = 2;    
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] Transform roomListBackground;    
    [SerializeField] GameObject roomListItemPrefab;

    [SerializeField] GameObject PlayerListItemPrefab;
    [SerializeField] Transform playerListBackground;

    [SerializeField] GameObject startButton;
    [SerializeField] GameObject mapSelectButton;
    

 

    #region Private Serializable Fields

    private List<RoomInfo> _onRoomInfoChangedObservable;

    #endregion

    #region Private Fields

    bool isConnecting;
    string gameVersion = "1";

    #endregion

    #region MonoBehaviour CallBacks

    void Awake()
    {
        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    #endregion
    
    [SerializeField] private GameObject controlPanel;        
    [SerializeField] private GameObject progressLabel;
 
    
    #region MonoBehaviourPunCallbacks Callbacks       

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("����");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ����");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        Debug.Log("�� ����");

        if (!PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(false);
            mapSelectButton.SetActive(false);
        }
        else
        {
            startButton.SetActive(true);
            mapSelectButton.SetActive(true);
        }

        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(PlayerListItemPrefab, playerListBackground).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
    }


    //


    public void GameStart()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2 && stageNum > 0)
            PhotonNetwork.LoadLevel(stageNum);
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
                
        PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions { MaxPlayers = maxPlayersPerRoom }); // �Է¹��� �� �������� ���� �����ϰ� �ִ� �ο��� 2������ ����
        roomNameText.text = roomNameInputField.text;
    }

    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {        
        foreach(Transform trans in roomListBackground)
        {
            Destroy(trans.gameObject);
        }

        if (roomList.Count == 0)
            return;

        Debug.Log("roomList.Count = "+ roomList.Count);

        for (int i = 0; i < roomList.Count; i++)
        {
            Instantiate(roomListItemPrefab, roomListBackground).GetComponent<RoomListItem>().Setup(roomList[i]);
        }
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListItemPrefab, playerListBackground).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();

        foreach (Transform child in playerListBackground)
        {
            Destroy(child.gameObject);
        }

        LobbyManager.Instance.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("�� ������");
    }


    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ������ ���� �� �濡 ���� ���� ���� ������ �� ���� ���н� Join Panel�� �ٽ� ����

        LobbyManager.Instance.roomPanel.SetActive(false);
        LobbyManager.Instance.joinPanel.SetActive(true);

        Debug.Log("�� ���� ����");
    }

    #endregion
}