using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor;
    SpriteRenderer spriteRenderer;
    bool hasPackage = false;
    [SerializeField] float timeUntilDestroy = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("package taked");
            hasPackage = true;
            Destroy(other.gameObject, timeUntilDestroy);
            spriteRenderer.color = hasPackageColor;
        }
            
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package sent");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
            
    }
}
