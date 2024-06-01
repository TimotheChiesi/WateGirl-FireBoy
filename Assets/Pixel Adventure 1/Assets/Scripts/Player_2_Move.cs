using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Move : PlayerMoveBase
{
    protected override KeyCode LeftKey => KeyCode.A;
    protected override KeyCode RightKey => KeyCode.D;
    protected override KeyCode JumpKey => KeyCode.W;
}
