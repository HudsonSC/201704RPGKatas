using System;
using System.Linq;
using Xunit;

namespace RpgKata
{
    public class CharacterJoinFaction
    {
        private readonly Character _actor = new Character();

        private readonly string _testFaction = "factionOne";
        [Fact]
        public void AddsFactionToList()
        {
            _actor.JoinFaction(_testFaction);

            Assert.True(_actor.IsMemberOf(_testFaction));
        }

        [Fact]
        public void DoesNotAddDuplicates()
        {
            _actor.JoinFaction(_testFaction);
            _actor.JoinFaction(_testFaction);

            Assert.Equal(1, _actor.Factions.Count());
        }
    }
}
