using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private CreatureType creatureType;    
    public CreatureType CreatureType { get { return creatureType; } }
}
