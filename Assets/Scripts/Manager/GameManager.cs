using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Inspector Variables
    public Transform player;
    public float startSpeed = 100;
    public float speedIncreaseRate = 10f;
    public List<RoomSet> roomSets;
    public int roomAmountInTheSet = 5;

    public int currentScore = 0;
    #endregion

    #region Private Variables
    private PlayerController playerController;
    private Vector2 playerStartPosition;
    [HideInInspector] public float currentSpeed = 0;
    [HideInInspector] public int generatedRoomCount = 0;
    private int currentRoomSet = 0;
    private int currentRoomSetRoomCount = 0;
    #endregion

    #region Singleton
    private static readonly object padlock = new object();
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerStartPosition = player.position;
        currentSpeed = startSpeed;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            if (playerController.isDead)
            {
                RestartGame();
            }
        }
        currentSpeed += (Time.deltaTime * speedIncreaseRate);
    }
    #endregion

    #region Custom Functions

    private void RestartGame()
    {
        StartCoroutine(HandleRestartGame());
    }

    private IEnumerator HandleRestartGame()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        playerController.resetPlayer();
        player.gameObject.SetActive(true);
    }

    public RoomPrefab nextRoom()
    {
        generatedRoomCount++;
        if (++currentRoomSetRoomCount >= roomAmountInTheSet)
        {
            if (++currentRoomSet >= roomSets.Count)
            {
                currentRoomSet = 0;
            }
            currentRoomSetRoomCount = 0;
        }
        int random = Random.Range(0, roomSets[currentRoomSet].roomPrefabs.Count);
        return roomSets[currentRoomSet].roomPrefabs[random];
    }

    #endregion

}
