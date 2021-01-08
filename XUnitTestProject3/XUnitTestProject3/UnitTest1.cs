using IIG.BinaryFlag;
using System;
using Xunit;

namespace XUnitTestProject3
{
    public class UnitTest1
    {
        [Fact]
        public void LengthExceptionTest()
        {
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(0));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868705));

            Assert.NotNull(new MultipleBinaryFlag(2));
            Assert.NotNull(new MultipleBinaryFlag(17179868704));
        }

        [Fact]
        public void CoverageConditionsTest()
        {
            Assert.NotNull(new MultipleBinaryFlag(32));
            Assert.NotNull(new MultipleBinaryFlag(34));
            Assert.NotNull(new MultipleBinaryFlag(66));
        }


        MultipleBinaryFlag FlagTest1 = new MultipleBinaryFlag(5);
        MultipleBinaryFlag FlagTest1_1 = new MultipleBinaryFlag(5, true);

        MultipleBinaryFlag FlagTest2 = new MultipleBinaryFlag(7, false);

        MultipleBinaryFlag FlagTest3 = new MultipleBinaryFlag(34);
        
        MultipleBinaryFlag FlagTest4 = new MultipleBinaryFlag(66, false);


        [Fact]
        public void NotNullFlagsTest()
        {
            Assert.NotNull(FlagTest1);
            Assert.NotNull(FlagTest1_1);
            Assert.NotNull(FlagTest2);
            Assert.NotNull(FlagTest3);
            Assert.NotNull(FlagTest4);
        }

        [Fact]
        public void EqualFlagsTest()
        {
            Assert.NotEqual(FlagTest1.ToString(), FlagTest2.ToString());
            Assert.NotEqual(FlagTest3.ToString(), FlagTest4.ToString());
            Assert.NotEqual(FlagTest2.ToString(), FlagTest4.ToString());

            Assert.Equal(FlagTest1.ToString(), FlagTest1_1.ToString());
        }

        [Fact]
        public void SetFlagTest()
        {
            FlagTest1.SetFlag(0);
            Assert.True(FlagTest1.GetFlag());

            FlagTest2.SetFlag(0);
            FlagTest2.SetFlag(6);
            Assert.False(FlagTest2.GetFlag());
        }

        [Fact]
        public void SetFlagRangeExceptionTest()
        {
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest1.SetFlag(6));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest2.SetFlag(9));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest3.SetFlag(35));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest4.SetFlag(67));
        }

        [Fact]
        public void SetFlagAllFlagsTest()
        {
            for (ulong i = 0; i < 7; i++)
            {
                FlagTest2.SetFlag(i);
            }
            Assert.True(FlagTest2.GetFlag());

            for (ulong i = 0; i < 66; i++)
            {
                FlagTest4.SetFlag(i);
            }
            Assert.True(FlagTest4.GetFlag());
        }

        [Fact]
        public void ResetFlagTest()
        {
            FlagTest1.ResetFlag(1);
            FlagTest1.ResetFlag(2);
            Assert.False(FlagTest1.GetFlag());

            FlagTest2.ResetFlag(2);
            Assert.False(FlagTest2.GetFlag());
        }

        [Fact]
        public void ResetFlagRangeException()
        {
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest1.ResetFlag(6));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest2.ResetFlag(9));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest3.ResetFlag(35));
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => FlagTest4.ResetFlag(67));
        }

        [Fact]
        public void ResetFlagAllFlagsTest()
        {
            for (ulong i = 0; i < 5; i++)
            {
                FlagTest1.ResetFlag(i);
            }
            Assert.False(FlagTest1.GetFlag());

            for (ulong i = 0; i < 34; i++)
            {
                FlagTest3.ResetFlag(i);
            }
            Assert.False(FlagTest3.GetFlag());
        }

        [Fact]
        public void EqualFlagsToStringTest()
        {
            Assert.Equal("TTTTT", FlagTest1.ToString());
            Assert.Equal("TTTTT", FlagTest1_1.ToString());
            Assert.Equal("FFFFFFF", FlagTest2.ToString());
        }

        [Fact]
        public void EqualSetFlagToStringTest()
        {
            FlagTest1.SetFlag(0);
            Assert.Equal("TTTTT", FlagTest1.ToString());

            FlagTest2.SetFlag(0);
            Assert.Equal("TFFFFFF", FlagTest2.ToString());

            for (ulong i = 0; i < 7; i++)
            {
                FlagTest2.SetFlag(i);
            }
            Assert.Equal("TTTTTTT", FlagTest2.ToString());
        }

        [Fact]
        public void EqualResetFlagToStringTest()
        {
            FlagTest1.ResetFlag(0);
            Assert.Equal("FTTTT", FlagTest1.ToString());

            for (ulong i = 0; i < 5; i++)
            {
                FlagTest1.ResetFlag(i);
            }
            Assert.Equal("FFFFF", FlagTest1.ToString());

            FlagTest2.ResetFlag(0);
            Assert.Equal("FFFFFFF", FlagTest2.ToString());
        }

        
    }
}