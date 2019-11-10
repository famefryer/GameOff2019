using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;

    private PlayerController playerController;
    private Vector2 playerStartPosition;
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

    
}
