using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    private bool dragging;
    private Vector2 offset, originalPosition;
    
    private PuzzleSlot _slot;
    void Awake()
    {
        originalPosition = transform.position;
    }

    public void Init(PuzzleSlot slot) {
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }
    void Update()
    {
        if(!dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - offset;
    }
    void OnMouseDown()
    {
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        transform.position = originalPosition;
        dragging = false;
    }

    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}