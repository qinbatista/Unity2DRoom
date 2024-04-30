using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log("OnTriggerExit2D");
        if (collider.gameObject.CompareTag("Cloth"))
        {
            collider.gameObject.GetComponent<ClothController>().IsOnTable = false;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        // Debug.Log("OnTriggerStay2D");
        if (collider.gameObject.CompareTag("Cloth"))
        {
            collider.gameObject.GetComponent<ClothController>().IsOnTable = true;
            collider.gameObject.GetComponent<ClothController>().TablePosition = this.transform.position + new Vector3(Random.Range(-0.3f, -0.5f), Random.Range(-1.5f, -2f), 0);
        }
    }
}
