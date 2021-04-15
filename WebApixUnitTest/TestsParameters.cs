// WebApiTest/WebApixUnitTest/TestsParameters.cs/15/04/2021

using System.Collections.Generic;

namespace WebApixUnitTest
{
	public class TestsParameters
	{
		public static IEnumerable<object[]> Urls => new List<object[]>
		{
			new object[]
			{
				"/calculos/mais/10/20"
			}
			, new object[]
			{
				"/calculos/menos/20/30"
			}
			, new object[]
			{
				"/calculos/divide/20/10"
			}
			, new object[]
			{
				"/calculos/multiplica/20/150"
			}
		};
	}
}
