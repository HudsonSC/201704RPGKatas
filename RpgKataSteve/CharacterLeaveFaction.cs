using System;
using System.Linq;
using Xunit;

namespace RpgKata
{
    public class CharacterLeaveFaction
    {
        private readonly Character _actor = new Character();

        private readonly string _testFaction = "factionOne";
        [Fact]
        public void RemovesFactionFromList()
        {
            _actor.JoinFaction(_testFaction);
            _actor.LeaveFaction(_testFaction);

            Assert.False(_actor.IsMemberOf(_testFaction));
        }

        [Fact]
        public void DoesNothingIfNotFound()
        {
            _actor.LeaveFaction(_testFaction);

            Assert.Equal(0, _actor.Factions.Count());
        }
    }
}
