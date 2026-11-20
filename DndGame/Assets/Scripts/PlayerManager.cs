using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement[] playerPrefab;
    [SerializeField] private Transform[] playerFollowPoints;
    InputMap inputMap;

    int playerIndex = 0;
    private bool isFollowing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputMap = InputMap.Instance;
        inputMap.NextPlayerEvent += NextPlayer;
        inputMap.FollowEvent += FollowPlayer;
        playerPrefab[playerIndex].SetActive(true);
        // The rest should be false
        for (int i = 1; i < playerPrefab.Length; i++)
        {
            playerPrefab[i].SetActive(false);
        }
    }

    void NextPlayer()
    {
        playerPrefab[playerIndex].SetActive(false);
        playerIndex = (playerIndex + 1) % playerPrefab.Length;
        playerPrefab[playerIndex].SetActive(true);
    }

    void FollowPlayer()
    {
        isFollowing = !isFollowing;
        playerPrefab[0].SetActive(true);
        for (int i = 1; i < playerPrefab.Length; i++)
        {
            playerPrefab[i].SetActive(false);
        }
    }

    void Update()
    {
        if (isFollowing)
        {
            for (int i = 1; i < playerPrefab.Length; i++)
            {
                Transform target = playerFollowPoints[i - 1];
                playerPrefab[i].Follow(target);
            }
        }
    }


    
}
