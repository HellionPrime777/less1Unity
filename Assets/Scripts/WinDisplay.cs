using System;
using TMPro;
using UnityEngine;

public class WinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private PlayerMover _player;

    private void Update()
    {
        if (_player.Score == 9)
        {
            _winText.gameObject.SetActive(true);
        }
    }
}
