using Extensions;
using UnityEngine.Events;

namespace GameMechanics.Input
{
    public class PlayerInputEvents : Monosingleton<PlayerInputEvents>
    {
        public UnityAction onShoot;
    }
}