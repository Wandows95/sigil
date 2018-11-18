using System;

// DIR : 1-Up, 2-URight, 3-Right, 4-LRight, 5-Down, 6-LLeft, 7-Left, 8-ULeft

public struct MoveCommand
{
    //int type; // Move, Cast Ability, Play Card, Attack
    int player_id;
    int unit_id;
    int mag_x;
    int mag_y;
}

public struct AttackCommand
{
    int player_id;
    int unit_id;
    int target_unit_id; // Direct target unit?
    int dir; // or direction to attack?
}

public struct AbilityCommand
{
    int player_id;
    int unit_id;
    int ability_id;
    int target_unit_id;
    int dir;
}

public struct PlayCardCommand
{
    int player_id;
    int unit_id;
    int card_id;
    int target_id;
}

public struct PassTurnCommand
{
    // PASS
}