using Neisum.ScriptableEvents;
using UnityEngine;
using UnityEngine.Events;

public class ShootEventListener : ScriptableListener<Transform, OnShootEvent, UnityEvent<Transform>>
{ }
