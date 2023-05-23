using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private Material _materialToChangeTo;
    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void UpdateMaterial()
    {
        _meshRenderer.material = _materialToChangeTo;
    }
}
