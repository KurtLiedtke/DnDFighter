using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    void Start()
    {
        
    }


    void Update()
    {
        HandleMovement();    
    }

    void HandleMovement()
    {
        Vector2 movementInput = InputMap.Instance.GetMovementInput();
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        transform.Translate(movement * Time.deltaTime * 5f);
    }
}
