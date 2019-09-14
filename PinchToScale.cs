using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach to gameobject to enable it to be scaled by pinch gesture
/// </summary>
public class PinchToScale : MonoBehaviour
{
    [SerializeField]
    private float _scaleSpeed = 1;

    [SerializeField]
    private float _maxScale = 5;

    [SerializeField]
    private float _minScale = 0.5f;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            // store touches
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // find the position in the previous frame of each touch.
            Vector2 touchOnePrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touchTwoPrevPos = touch2.position - touch2.deltaPosition;

            // find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchOnePrevPos - touchTwoPrevPos).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            // find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            transform.localScale = transform.localScale - (deltaMagnitudeDiff*_scaleSpeed)*(Vector3.one);

            if (transform.localScale.x < _minScale)
            {
                transform.localScale = Vector3.one * _minScale;
                return;
            }
                
            if (transform.localScale.x > _maxScale)
            {
                transform.localScale = Vector3.one * _maxScale;
                return;
            }
        }
    }
}