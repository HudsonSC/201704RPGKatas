using System;
using Xunit;

namespace RpgKata
{
    public class CharacterDealDamage
    {
        private readonly Character _attacker = new Character();
        private readonly Character _target = new Character();

        [Fact]
        public void SubtractsDamageFromHealth()
        {
            _attacker.DealDamage(_target, 500);
            Assert.Equal(500, _target.Health);
        }

        [Fact]
        public void ReducesHealthToZeroIfHealthExceeded()
        {
            _attacker.DealDamage(_target, Constants.MAXHEALTH + 1);
            Assert.Equal(0, _target.Health);
        }

        [Fact]
        public void ThrowsExceptionIfTargetingSelf()
        {
            var exception = Record.Exception(() => _attacker.DealDamage(_attacker, 1));

            Assert.IsType<IllegalTargetException>(exception);
        }

        [Theory]
        [InlineData(1,1,100,100)]
        [InlineData(1,5,100,100)]
        [InlineData(1,6,100,50)]
        [InlineData(5,1,100,100)]
        [InlineData(6,1,100,200)]
        public void DealsDamageBasedOnLevels(int attackerLevel, 
            int targetLevel, 
            int baseDamage, 
            int modifiedDamage)
        {
            _attacker.Level = attackerLevel;
            _target.Level = targetLevel;

            _attacker.DealDamage(_target, baseDamage);

            int expectedHealth = 1000 - modifiedDamage;
            Assert.Equal(expectedHealth, _target.Health);
        }

        [Fact]
        public void DoesNoDamageAtRange3ForMeleeAttacker()
        {
            _target.CurrentRange = 3;
            _attacker.DealDamage(_target, 1);
            Assert.Equal(Constants.MAXHEALTH, _target.Health);
        }

        [Fact]
        public void DoesNoDamageAtRange21ForRangedAttacker()
        {
            _attacker.SetType("Ranged");
            _target.CurrentRange = 21;
            _attacker.DealDamage(_target, 1);
            Assert.Equal(Constants.MAXHEALTH, _target.Health);
        }

        [Fact]
        public void WhatDoesUintDo()
        {
            uint something = 100;
            checked {
            uint result = something - 200;
            
            Console.WriteLine($"Value: {result}");

            Assert.True(0 == result);
            }
        }

    }
}
