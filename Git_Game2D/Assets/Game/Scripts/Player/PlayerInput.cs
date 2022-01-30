using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerInput : MonoBehaviour
{
    private struct PlayerInputConstants
    { 
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Jump = "Jump";
    }
    public Vector2 GetMovementInput()
    {
        // Input Teclado
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);

        // se o input do teclado for zero, tentamos ler o input do celular
        if(Mathf.Approximately(horizontalInput, 0.0f))
        { 
            horizontalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal);
        }
        return new Vector2(horizontalInput, 0);
    }

    public bool IsJumpButtonDown()
    { 
        bool isKeyBoardButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);
        return isKeyBoardButtonDown || isMobileButtonDown;
    }

    public bool IsJumpButtonHeld()
    {
        bool isKeyBoardButtonHeld = Input.GetKey(KeyCode.Space);
        bool isMobileButtonHeld = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);
        return isKeyBoardButtonHeld || isMobileButtonHeld;
    }

    public bool IsCrouchButtonDown()
    {
        bool isKeyBoardButtonDown = Input.GetKeyDown(KeyCode.S);
        bool isMobileButtonDown = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) < 0;
        return isKeyBoardButtonDown || isMobileButtonDown;
    }

    public bool IsCrouchButtonUp()
    {
        bool isKeyBoardButtonUp = Input.GetKey(KeyCode.S) == false;
        bool isMobileButtonUp = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) >= 0;
        return isKeyBoardButtonUp && isMobileButtonUp;
    }
}
