using System;
using System.Collections.Generic;
using UnityEngine;

class DeckManager
{
    List<Card> deck; 
    int total_deck_size;
    int cur_deck_size;

    public DeckManager()
    {
        total_deck_size = 0;
    }

    public void LoadDeck(int deck_size, Card[] cards)
    {
        if(total_deck_size == 0)
        {
           deck = new List<Card>(cards);
           total_deck_size = deck.Count;
           cur_deck_size = total_deck_size;
        }
    }

    public Card DrawCard()
    {
        if(cur_deck_size > 0 && total_deck_size > 0)
        {
            Card drawn = deck[0];
            deck.RemoveAt(0);
            cur_deck_size--;

            return drawn;
        }
        else
        {
            return new Card(-1); // return dead card
        }
    }
}

class HandManager
{
    List<Card> hand;
    int max_hand_size;
    int base_hand_size;
    DeckManager deck;

    public HandManager(DeckManager deck, int max_hand_size, int base_hand_size)
    {
        this.deck = deck;
        
        if(base_hand_size > max_hand_size)
        {
            this.max_hand_size = base_hand_size;
        }
        else
        {
            this.max_hand_size = max_hand_size;
            this.base_hand_size = base_hand_size;
        }
    }

    public void DrawStartingHand()
    {
        if(hand.Count == 0)
        {
            for(int i = 0; i < base_hand_size; i++)
            {
                // Check for dead card
                hand[i] = deck.DrawCard();
            }
        }
    }
}


class ManaManager
{
    int cur_mana;
    int max_mana;
    bool can_gain_mana;
    bool can_generate;

    public void GenerateMana()
    {
        if(can_generate && cur_mana < max_mana)
        {
            cur_mana++;
        }
    }

    public bool ExpendMana(int num_mana)
    {
        if((cur_mana - num_mana) > 0)
        {
            cur_mana -= num_mana;
            return true;
        }
        else
        {
            return false;
        }
    }
}


public struct Card
{
    public int id;
    public int effect_id;
    public int mana_cost;
    public string description;

    public bool is_played;

    public Card(int new_id=-1, int effect_id=-1, int mana_cost=10000, string description="")
    {
        id = new_id;
        this.effect_id = effect_id;
        this.mana_cost = mana_cost;
        this.description = description;
        is_played = false;
    }
}