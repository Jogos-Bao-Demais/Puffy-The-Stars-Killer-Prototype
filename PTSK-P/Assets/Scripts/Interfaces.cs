using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    void TakeDemage(float damage);
}

interface IIntangible
{
    public bool IsIntangible { get; }
}