using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelector : MonoBehaviour
{
    MouseInput mouseInput;
    
    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    }

    
    void Start()
    {
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick()
    {
        
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero, 0f);
        if (hit)
        {
            Debug.Log("Clicked Object");
            hit.transform.gameObject.GetComponent<BlocksAI>().selected = true;
        }
        else return;
    }

    
}
