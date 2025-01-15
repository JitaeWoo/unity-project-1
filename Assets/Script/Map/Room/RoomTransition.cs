using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    private enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    [SerializeField] private GameObject _nextRoom;
    [SerializeField] private Direction _direction;
    private RoomHandler _nextRoomHandler;

    private void Awake()
    {
        if(_nextRoom != null)
        {
            _nextRoomHandler = _nextRoom.GetComponent<RoomHandler>();
        }
    }

    private static readonly Dictionary<Direction, Vector2> _directionToVector = new Dictionary<Direction, Vector2>
    {
        { Direction.Up, new Vector2(0, 1) },
        { Direction.Down, new Vector2(0, -1) },
        { Direction.Right, new Vector2(1, 0) },
        { Direction.Left, new Vector2(-1, 0) }
    };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 direction = _directionToVector[_direction];
            RoomManager.Instance.MoveToRoom(_nextRoomHandler, direction);
        }
    }
}
