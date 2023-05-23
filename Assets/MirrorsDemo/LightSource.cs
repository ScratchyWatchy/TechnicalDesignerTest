using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class LightSource : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    
    [SerializeField]
    private int _maxReflectionCount = 5;
    
    [SerializeField]
    private string _tagToHit = "Mirror";
    
    [SerializeField]
    private string _tagToActivate = "LightGoal";
    
    [SerializeField]
    private Transform _lightSource;
    
    [SerializeField]
    private LayerMask _layerMask;
    
    public UnityEvent onTargetHit;

    private bool _hasHitTarget = false;
    
    
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _maxReflectionCount;
        _lineRenderer.SetPosition(0, transform.position);    
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, _lightSource.position);
        var origin = new HitMirror() {_position = _lightSource.position, _direction = _lightSource.forward};
        for (int i = 1; i < _maxReflectionCount; i++)
        {
            origin = CastRay(origin._position.Value, origin._direction.Value);
            if (origin.isMirror)
            {
                _lineRenderer.SetPosition(i, origin._position.Value);
            }
            else
            {
                for (int j = i;  j < _maxReflectionCount; j++)
                {
                    _lineRenderer.SetPosition(j, origin._position.Value);
                }
                break;
            }
        }
    }

    private HitMirror CastRay(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;
        var nextHit = new HitMirror { _position = null, _direction = null, isMirror = false};
        if (origin == null) return nextHit;
        
        if (Physics.Raycast(origin, direction,out hit, 1000f, _layerMask))
        {
            nextHit._position = hit.point;
            nextHit._direction = Vector3.Reflect(direction, hit.normal);
            if (hit.collider.gameObject.CompareTag(_tagToHit)) nextHit.isMirror = true;
            if (hit.collider.gameObject.CompareTag(_tagToActivate) && !_hasHitTarget)
            {
                onTargetHit.Invoke();
                _hasHitTarget = true;
            }
        }
        else
        {
            nextHit._position = origin + direction * 1000f;
            nextHit._direction = direction;
        }
        return nextHit;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(_lightSource.position, _lightSource.position + _lightSource.forward * 100, Color.red);
    }

    public struct HitMirror
    {
        public Vector3? _position;
        public Vector3? _direction;
        public bool isMirror;
    }
}
