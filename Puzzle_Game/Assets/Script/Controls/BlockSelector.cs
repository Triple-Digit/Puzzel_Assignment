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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.transform != null)
            {                
                hit.transform.gameObject.GetComponent<BlocksAI>().DestroyBlock();
            }            
        }
        else return;
    }
        
        
    

    
}
