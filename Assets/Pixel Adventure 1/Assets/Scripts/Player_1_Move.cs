using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Move : PlayerMoveBase
{
    protected override KeyCode LeftKey => KeyCode.LeftArrow;
    protected override KeyCode RightKey => KeyCode.RightArrow;
    protected override KeyCode JumpKey => KeyCode.UpArrow;
}
