using System;
using Xunit;

namespace RpgKata
{
    public class CharacterHeal
    {
        private readonly Character _healer = new Character();
        private readonly Character _attacker = new Character();

        [Fact]
        public void IncreasesHealth()
        {
            _attacker.DealDamage(_healer, 500);
            _healer.Heal(_healer, 100);
            Assert.Equal(600, _healer.Health);
        }

        [Fact]
        public void DoesNotExceedMaxHealth()
        {
            _attacker.DealDamage(_healer, 100);
            _healer.Heal(_healer, 200);
            Assert.Equal(Constants.MAXHEALTH, _healer.Health);
        }

        [Fact]
        public void DoesNotAffectDeadCharacters()
        {
            _attacker.DealDamage(_healer, Constants.MAXHEALTH);
            _healer.Heal(_healer, 200);
            Assert.Equal(0, _healer.Health);
        }

        [Fact]
        public void CanHealAlliedCharacters()
        {
            var target = new Character();
            string testFaction = "faction";
            target.JoinFaction(testFaction);
            _healer.JoinFaction(testFaction);
            _attacker.DealDamage(target, 100);
            _healer.Heal(target, 50);
            Assert.Equal(Constants.MAXHEALTH - 50, target.Health);
        }

        [Fact]
        public void ThrowsExceptionIfNotTargetingAlly()
        {
            var exception = Record.Exception(() => _healer.Heal(_attacker, 1));

            Assert.IsType<IllegalTargetException>(exception);
        }      
    }
}
