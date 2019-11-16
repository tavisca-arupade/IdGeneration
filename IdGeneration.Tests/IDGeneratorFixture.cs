using IDGeneration;
using System;
using Xunit;

namespace IdGeneration.Tests
{
    public class IDGeneratorFixture
    {
        [Fact]
        public void Test_to_check_id_not_null()
        {
            IdGenerator generator = new IdGenerator();

            Assert.NotNull(generator.GetID());
        }

        [Fact]
        public void Test_to_check_length_of_id_generated_is_9_bytes()
        {
            IdGenerator generator = new IdGenerator();
            int expectedLength = 9;

            Assert.Equal(expectedLength, generator.GetID().Length);
        }
    }
}
