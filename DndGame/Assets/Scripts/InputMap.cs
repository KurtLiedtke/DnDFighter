using UnityEngine;

public class InputMap : MonoBehaviour
{
    public static InputMap Instance { get; private set; }
    GameInput gameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        gameInput = new GameInput();
        gameInput.Player.Enable();        
    }

    public Vector2 GetMovementInput()
    {
        Vector2 movementInput = gameInput.Player.Move.ReadValue<Vector2>();
        Debug.Log(movementInput);
        return movementInput.normalized;
    }



}
