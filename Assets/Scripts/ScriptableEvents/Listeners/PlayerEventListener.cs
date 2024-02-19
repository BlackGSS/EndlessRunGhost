using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Neisum.ScriptableEvents
{
    public class PlayerEventListener : ScriptableListener<PlayerControl, PlayerSpawn, UnityEvent<PlayerControl>>
    { }
}