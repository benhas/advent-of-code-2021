using Microsoft.VisualBasic;
using Xunit;

namespace SonarSweepTests
{
    public class SonarSweepTests
    {
        [Fact]
        public void CalculateDepthIncreases_DepthsArray_ReturnIncreases()
        {
            var depths = new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
            const int expectedIncreases = 7;
            var foundIncreases = SonarSweep.SonarSweep.CalculateDepthIncreases(depths);
            Assert.Equal(expectedIncreases, foundIncreases);
        }

        [Theory]
        [InlineData(new int[]{199,200,208},new int[]{607})]
        [InlineData(new int[]{199, 200, 208, 210, 200, 207, 240, 269, 260, 263},
            new int[] {607, 618,618,617,647,716,769,792})]
        public void CalculateDepthRollingSums_DepthsArray_ReturnRollingSumsArray(int[] depths, int[] expectedDepths)
        {
            var foundDepths = SonarSweep.SonarSweep.GetRollingSumArray(depths);
            Assert.Equal(expectedDepths, foundDepths);
        }
    }
}