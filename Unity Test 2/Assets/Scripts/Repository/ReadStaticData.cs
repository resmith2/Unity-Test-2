using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Models;
using Newtonsoft.Json;

namespace Repository
{
	public class ReadStaticData
	{
		public List<PlanetBody> ReadSolBodyies()
		{
			var sol = File.ReadAllText("/Users/rsmith/Documents/GitHub/Unity-Test-2/Unity Test 2/Assets/Data/Sol.json");
			var bodies = JsonConvert.DeserializeObject<List<PlanetBody>>(sol);

			return bodies;
		}
	}
}