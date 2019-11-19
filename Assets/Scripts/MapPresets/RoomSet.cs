using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room Set", menuName = "Room/Room Set")]
public class RoomSet : ScriptableObject
{

    public List<RoomPrefab> roomPrefabs;

}
