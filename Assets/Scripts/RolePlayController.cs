using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RoleAnimationController))]
public class RolePlayController : MonoBehaviour
{
    RoleAnimationController _roleAnimationController;
    Coroutine _dragCoroutine;
    WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
    Vector3 _offset;
    bool _isNearSofa = false;
    Vector2 _SoFaPosition = new Vector2(0, 0);

    public bool IsNearSofa { get => _isNearSofa; set => _isNearSofa = value; }
    public Vector2 SoFaPosition { get => _SoFaPosition; set => _SoFaPosition = value; }

    void Start()
    {
        _roleAnimationController = GetComponent<RoleAnimationController>();
    }
    void OnMouseDown()
    {
        _offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        _roleAnimationController.PickedUp();
        _dragCoroutine = StartCoroutine(CoroutineOnMouseDrag());
    }
    IEnumerator CoroutineOnMouseDrag()
    {
        while (true)
        {
            //add pivot point to the mouse position
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + _offset;
            yield return _waitForFixedUpdate;
        }
    }
    void OnMouseUp()
    {
        _roleAnimationController.Dropped();
        StopCoroutine(_dragCoroutine);
        if (_isNearSofa)
        {
            this.transform.position = SoFaPosition + new Vector2(0.77f, 1.4f);
            _roleAnimationController.SetOnSofa();
        }
    }

}
