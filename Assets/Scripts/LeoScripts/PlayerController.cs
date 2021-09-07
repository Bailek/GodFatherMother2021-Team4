using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerEntity _entity = null;

    [SerializeField] private string _rewiredPlayerName = "Player";
    private Player _rewiredPlayer = null;

    private void Awake()
    {
        _rewiredPlayer = ReInput.players.GetPlayer(_rewiredPlayerName);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = _rewiredPlayer.GetAxis2D("MoveHorizontal", "MoveVertical");
        moveDir.Normalize();

        _entity.Move(moveDir);

        if (_rewiredPlayer.GetButtonDown("Interaction"))
        {
           Debug.Log("Interact");
        }
    }
}
