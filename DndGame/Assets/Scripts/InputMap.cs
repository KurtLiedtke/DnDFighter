using UnityEngine;

public class InputMap : MonoBehaviour
{
    public static InputMap Instance { get; private set; }
    GameInput gameInput;
    public event System.Action MouseClickEvent;
    public event System.Action NextPlayerEvent;
    public event System.Action FollowEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        gameInput = new GameInput();
        gameInput.Player.Enable();      
        gameInput.Player.Click.performed += ctx => MouseClick();  
        gameInput.Player.Next.performed += ctx => NextPlayer();
        gameInput.Player.Follow.performed += ctx => Follow();
    }

    public Vector2 GetMovementInput()
    {
        Vector2 movementInput = gameInput.Player.Move.ReadValue<Vector2>();


        return movementInput.normalized;
    }

    private void MouseClick()
    {
        MouseClickEvent?.Invoke();
    }

    private void NextPlayer()
    {
        NextPlayerEvent?.Invoke();
    }

    private void Follow()
    {
        FollowEvent?.Invoke();
    }



}
