using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ResourceScript : MonoBehaviour
{
    public GameObject itemprefab;
    private bool isHit = false;

    private Color originalColor;
    public Color hitColor = Color.red;


    public float ResourceHP = 2.0f;
    private void OnEnable()
    {
        if (ResourceHP <= 0)
        {
            ResourceHP = 2.0f;
        }
    }
    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon") && !isHit)
        {

            Debug.Log("¶§·È´Ù.");
            if (ResourceHP > 0)
            { 
                isHit = true;
                ResourceHP--;
                GetComponent<Renderer>().material.color = hitColor;
                Debug.Log(ResourceHP);

                StartCoroutine(ResetColorAfterDelay(0.2f));
            }
            else
            {
                Die();
            }
        }

    }

    private void Die()
    {
        gameObject.SetActive(false);
        DropItem();
    }

    private IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isHit = false;
        ResetResource();
    }

    public void ResetResource()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    private void DropItem()
    {
        Instantiate(itemprefab, transform.position, Quaternion.identity);
    }
}
