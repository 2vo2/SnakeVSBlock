using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;

    private SnakeInput _snakeInput;
    private TailGenerator _tailGenerator;
    private List<Segment> _tail;

    private void Awake()
    {
        _snakeInput = GetComponent<SnakeInput>();
        _tailGenerator = GetComponent<TailGenerator>();
        
        _tail = _tailGenerator.Generate();
    }

    private void FixedUpdate()
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * (_speed * Time.fixedDeltaTime));

        _snakeHead.transform.up = _snakeInput.GetDirectionToClick(_snakeHead.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _snakeHead.transform.position;

        foreach (var tailSegment in _tail)
        {
            Vector3 tempPosition = tailSegment.transform.position;
            tailSegment.transform.position = Vector2.Lerp(tailSegment.transform.position,
                previousPosition, _tailSpringiness * Time.fixedDeltaTime);
            previousPosition = tempPosition;
        }
        
        _snakeHead.Move(nextPosition);
    }
}