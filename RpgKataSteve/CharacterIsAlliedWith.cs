using System;
using System.Linq;
using Xunit;

namespace RpgKata
{
    public class CharacterIsAlliedWith
    {
        private readonly Character _actor = new Character();
        private readonly Character _target = new Character();

        private readonly string _testFaction = "factionOne";
        private readonly string _testFaction2 = "factionTwo";
        
        [Fact]
        public void ReturnsFalseIfNoFactions()
        {
            Assert.False(_actor.IsAlliedWith(_target));
        }
        [Fact]
        public void ReturnsFalseIfDifferentFactions()
        {
            _actor.JoinFaction(_testFaction);
            _target.JoinFaction(_testFaction2);
            Assert.False(_actor.IsAlliedWith(_target));
        }
        [Fact]
        public void ReturnsTrueIfCommonFactions()
        {
            _actor.JoinFaction(_testFaction);
            _target.JoinFaction(_testFaction);
            _target.JoinFaction(_testFaction2);
            Assert.True(_actor.IsAlliedWith(_target));
            Assert.True(_target.IsAlliedWith(_actor));
        }
        [Fact]
        public void ReturnsTrueIfComparingToSelf()
        {
            Assert.True(_actor.IsAlliedWith(_actor));
        }
    }
}
