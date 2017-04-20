using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgKata
{
    public class Character
    {
        public int Health { get; private set;} = Constants.MAXHEALTH;
        public int Level { get; set; } = 1;
        public bool IsAlive => Health > 0;
        public int MaxRange { get; private set;} = 2;

        public string Type { get; private set; } = "Melee";
        public int CurrentRange { get; set;}
        private readonly List<string> _factions = new List<string>();
        public IEnumerable<string> Factions { 
            get
            { 
                return _factions.AsReadOnly();
            }
        }
        public void JoinFaction(string faction)
        {
            if(Factions.Any(f => f == faction)) return;
            _factions.Add(faction);
        }
        public void LeaveFaction(string faction)
        {
            _factions.RemoveAll(f => f == faction);
        }

        public bool IsMemberOf(string faction)
        {
            return Factions.Any(f => f == faction);
        }

        public bool IsAlliedWith(Character character)
        {
            if(character == this) return true;
            return character.Factions.Intersect(Factions).Any();
        }

        public void SetType(string characterType)
        {
            if(characterType == "Melee")
            {
                Type = characterType;
                MaxRange = 2;
            }
            if(characterType == "Ranged")
            {
                Type = characterType;
                MaxRange = 20;
            }
        }
        public void DealDamage(Character target, int amount)
        {
            if(target == this)
            {
                throw new IllegalTargetException("Cannot target yourself");
            }
            if(target.CurrentRange > MaxRange)
            {
                return;
            }
            int adjustedAmount = amount;
            int levelDifference = target.Level - Level;
            if(levelDifference >= 5)
            {
                adjustedAmount = adjustedAmount / 2;
            }
            if(levelDifference <= -5)
            {
                adjustedAmount = adjustedAmount * 2;
            }
            target.Health -= adjustedAmount;
            if(target.Health < 0)
            {
                target.Health = 0;
            }
        }

        public void Heal (Character character, int amount)
        {
            //if(character != this)
            if(!IsAlliedWith(character))
            {
                throw new IllegalTargetException("Can only heal allies");
            }

            if(!character.IsAlive) return;
            character.Health += amount;
            if(character.Health > Constants.MAXHEALTH)
            {
                character.Health = Constants.MAXHEALTH;
            }
        }
    }
}
