using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventListener : ScriptableListener<PlayerControl, PlayerEvent, UnityEvent<PlayerControl>>
{ }