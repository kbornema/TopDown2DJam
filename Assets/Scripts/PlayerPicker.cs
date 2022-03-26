using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    [SerializeField]
    private Player _player = default;
    public Player GetPlayer() => _player;
}
