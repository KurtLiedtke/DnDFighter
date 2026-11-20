using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isActive = false;
    InputMap inputMap;
    
    
    void Start()
    {
        inputMap = InputMap.Instance;
    }


    void Update()
    {
        HandleMovement();    
    }

    void HandleMovement()
    {
        if (!isActive) return;

        Vector2 movementInput = InputMap.Instance.GetMovementInput();
        Vector3 movement = new Vector3(movementInput.x, movementInput.y, 0f);
        transform.Translate(movement * Time.deltaTime * 5f);
    }

    

    public void SetActive(bool active)
    {
        isActive = active;
    }

    public void Follow(Transform target)
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
        }
    }
    
}
