using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothController : MonoBehaviour
{
    Vector3 _offset;
    Coroutine _dragCoroutine;
    WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
    GameObject _clothHanger;
    Rigidbody2D _rigidbody2D;
    Collider2D _collider2D;
    bool _isOnHanger = false;
    bool _isOnTable = false;
    Vector2 _tablePosition;
    [SerializeField] GameObject _ClothObj;
    [SerializeField] GameObject _ClothBoxObj;

    public Vector2 TablePosition { get => _tablePosition; set => _tablePosition = value; }
    public bool IsOnTable { get => _isOnTable; set => _isOnTable = value; }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _ClothObj.SetActive(true);
        _ClothBoxObj.SetActive(false);
        _rigidbody2D.gravityScale = 0;
        _collider2D.isTrigger = true;
    }
    void OnMouseDown()
    {
        // Debug.Log("OnMuseDown");
        _offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        _dragCoroutine = StartCoroutine(CoroutineOnMouseDrag());
        _collider2D.isTrigger = true;
        _rigidbody2D.gravityScale = 0;
    }
    IEnumerator CoroutineOnMouseDrag()
    {
        // Debug.Log("OnMouseDrag");
        while (true)
        {
            //add pivot point to the mouse position
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + _offset;
            yield return _waitForFixedUpdate;
        }
    }
    void OnMouseUp()
    {
        StopCoroutine(_dragCoroutine);
        // print("OnMouseDown: isOnHanger=" + isOnHanger);
        if (_isOnHanger)
        {
            this.transform.position = _clothHanger.transform.position + new Vector3(0, -1.42f, 0);
            _ClothObj.SetActive(true);
            _ClothBoxObj.SetActive(false);
        }
        else
        {
            _ClothObj.SetActive(false);
            _ClothBoxObj.SetActive(true);
            _rigidbody2D.gravityScale = 1;
            _collider2D.isTrigger = false;
        }

        if (IsOnTable)
        {
            this.transform.position = _tablePosition;
            _rigidbody2D.gravityScale = 0;
            _collider2D.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClothHanger"))
        {
            // Debug.Log("OnTriggerEnter2D");
            _clothHanger = other.gameObject;
            _isOnHanger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClothHanger"))
        {
            // Debug.Log("OnTriggerExit2D");
            _isOnHanger = false;
        }
    }
}
