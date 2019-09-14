using UnityEngine;

/// <summary>
/// Attach To a gameobject to enable it to be rotated by left/ right swipe
/// </summary>
public class SwipeToRotate : MonoBehaviour
{
    private Touch _touch;

    private Quaternion _yRotation;

    [SerializeField]
    private float _rotationSpeed = 0.1f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                _yRotation = Quaternion.Euler(0f, -_touch.deltaPosition.x * _rotationSpeed, 0f);

                transform.rotation = _yRotation * transform.rotation;
            }
        }
    }
}
