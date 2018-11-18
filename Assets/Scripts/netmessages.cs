using System;

public struct ChatMessage
{
    int user_id;
    string message;
}

public struct DiscardMessage
{
    int user_id;
    int card_id;
}