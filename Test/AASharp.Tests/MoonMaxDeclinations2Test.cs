using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class MoonMaxDeclinations2Test
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[] //January 2019
            {
                AASMoonMaxDeclinations2.Algorithm.MeeusTruncated,
                2458484.5,
                2458484.5+31,
                0.007,
                new List<AASMoonMaxDeclinationsDetails2>
                {
                    new AASMoonMaxDeclinationsDetails2
                    {
                        type = AASMoonMaxDeclinationsDetails2.Type.MaxSouthernDeclination,
                        JD = 2458489.28021553,
                        Declination = -21.552526151967026,
                        RA = 18.862752895249574
                    },
                    new AASMoonMaxDeclinationsDetails2
                    {
                        type = AASMoonMaxDeclinationsDetails2.Type.MaxNorthernDeclination,
                        JD = 2458503.472287612,
                        Declination = 21.543782916932919,
                        RA = 6.8654590488336549
                    }
                }
            };
            yield return new object[] //June 2019
            {
                AASMoonMaxDeclinations2.Algorithm.MeeusTruncated,
                2458635.5,
                2458635.5+30,
                0.007,
                new List<AASMoonMaxDeclinationsDetails2>
                {
                    new AASMoonMaxDeclinationsDetails2
                    {
                        type = AASMoonMaxDeclinationsDetails2.Type.MaxNorthernDeclination,
                        JD = 2458640.0420427904,
                        Declination = 22.361824076911734,
                        RA = 6.8744711653436106
                    },
                    new AASMoonMaxDeclinationsDetails2
                    {
                        type = AASMoonMaxDeclinationsDetails2.Type.MaxSouthernDeclination,
                        JD = 2458653.1449988135,
                        Declination = -22.380243466138317,
                        RA = 18.883049687802234
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void CalculateTest(AASMoonMaxDeclinations2.Algorithm algorithm, double startJD, double endJD, double stepInterval, List<AASMoonMaxDeclinationsDetails2> expectedResults)
        {
            var results = AASMoonMaxDeclinations2.Calculate(startJD, endJD, stepInterval, algorithm);
            
            foreach (AASMoonMaxDeclinationsDetails2 expectedResult in expectedResults)
            {
                AASMoonMaxDeclinationsDetails2 result = results.FirstOrDefault(r => r.type == expectedResult.type);
                Assert.NotNull(result);
                Assert.Equal(expectedResult.type, result.type);
                Assert.Equal(expectedResult.RA, result.RA);
                Assert.Equal(expectedResult.Declination, result.Declination);
                Assert.Equal(expectedResult.JD, result.JD);
            }
        }

    }
}