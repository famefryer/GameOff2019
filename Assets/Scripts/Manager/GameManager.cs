using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Inspector Variables
    public Transform player;
    #endregion

    #region Private Variables
    private PlayerController playerController;
    private Vector2 playerStartPosition;
    #endregion

    #region Singleton
    private static readonly object padlock = new object();
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
    }

    private GameManager()
    {
        Init();
    }

    public void Init()
    {
        // TODO
    }
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerStartPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isDead)
        {
            RestartGame();
        }
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
    #endregion

}
