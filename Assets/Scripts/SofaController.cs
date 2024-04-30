using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaController : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log("OnTriggerExit2D");
        if (collider.gameObject.CompareTag("Role"))
        {
            collider.gameObject.GetComponent<RolePlayController>().IsNearSofa = false;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        // Debug.Log("OnTriggerStay2D");
        if (collider.gameObject.CompareTag("Role"))
        {
            collider.gameObject.GetComponent<RolePlayController>().IsNearSofa = true;
            collider.gameObject.GetComponent<RolePlayController>().SoFaPosition = this.transform.position;
        }
    }
}
