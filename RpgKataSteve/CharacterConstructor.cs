using System;
using System.Linq;
using Xunit;

namespace RpgKata
{
    public class CharacterConstructor
    {
        [Fact]
        public void SetsHealthTo1000()
        {
            var character = new Character();

            Assert.Equal(1000, character.Health);
        }

        [Fact]
        public void SetsLevelTo1()
        {
            var character = new Character();

            Assert.Equal(1, character.Level);
        }

        [Fact]
        public void SetsIsAliveTrue()
        {
            var character = new Character();

            Assert.Equal(true, character.IsAlive);
        }
        [Fact]
        public void SetsMeleeMaxRangeTo2()
        {
            var character = new Character();

            Assert.Equal(2, character.MaxRange);
        }
        [Fact]
        public void SetsRangedMaxRangeTo20()
        {
            var character = new Character();
            character.SetType("Ranged");

            Assert.Equal(20, character.MaxRange);
        }
        
        [Fact]
        public void SetsFactionToEmptyList()
        {
            var character = new Character();

            Assert.Equal(0, character.Factions.Count());
        }

    }
}
