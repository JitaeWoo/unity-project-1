using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class RoomManager : Singleton<RoomManager>
{
    public RoomHandler CurrentRoom;
    public void RoomActivate(RoomHandler room)
    {
        CurrentRoom = room;
        room.SetRoomActive(true);
        PlayerCameraManager.Instance.SetCameraBoundary(room.GetCameraBoundary());
    }

    public void MoveToRoom(RoomHandler nextRoom, Vector2 direction)
    {
        if (nextRoom != null)
        {
            CurrentRoom.SetRoomActive(false);

            RoomActivate(nextRoom);

            PlayerController.Instance.transform.position += (Vector3)direction;
        }
        else
        {
            Debug.LogError("Next room is not assigned!");
        }
    }

    public RoomHandler FindRoom(string roomID)
    {
        RoomHandler[] allrooms = FindObjectsOfType<RoomHandler>();
        foreach (var room in allrooms)
        {
            if (room.RoomID == roomID)
            {
                return room;
            }
        }

        Debug.Log($"{roomID}을 찾을 수 없습니다.");
        return null;
    }
}
