using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    private PlatformVG.PlayerActions _playerActions;
    private PlatformVG controls;
    [FormerlySerializedAs("jump")] [SerializeField] private bool jumpPressPress;
    private bool _jumpHold;

    public static event Action Pause = delegate { };

    public bool JumpHold
    {
        get => _jumpHold;
        set => _jumpHold = value;
    }

    public bool JumpPress
    {
        get => jumpPressPress;
        set => jumpPressPress = value;
    }


    void Awake()
    {
        controls = new PlatformVG();
        _playerActions = controls.Player;
        _playerActions.SpacePressed.performed += x => jumpPressed();
        _playerActions.SpaceRelease.performed += x => jumpReleased();
        _playerActions.HoldJump.performed += x => jumpHold();
        _playerActions.ESC.started += x => escPressed();
    }

    private void escPressed()
    {

        Pause.Invoke();
    }

    void jumpHold()
    {
        _jumpHold = true;
    }

    private void jumpPressed()
    {
        jumpPressPress = true;
        jumpHold();
    }

    private void jumpReleased()
    {
        jumpPressPress = false;
        _jumpHold = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}