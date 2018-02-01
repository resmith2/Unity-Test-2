using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
	public class PlanetBody
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid Parent { get; set; }
		public int BodyClassId { get; set; }
		public int BodyTypeId { get; set; }
		public decimal OrbitalDistance { get; set; }
		public decimal OrbitalDistanceMK { get; set; }
		public decimal Decimal { get; set; }
		public decimal Density { get; set; }
		public int Radius { get; set; }
		public decimal Gravity { get; set; }
		public decimal Mass { get; set; }
		public decimal Escape { get; set; }
		public decimal TidalForce { get; set; }
		public bool TidalLock { get; set; }
		public decimal Tilt { get; set; }
		public decimal Eccentricity { get; set; }
		public decimal Roche { get; set; }
		public int CompositionTypeId { get; set; }
		public int TectonicActivityId { get; set; }
		public decimal MagneticField { get; set; }
		public decimal BaseTemp { get; set; }
		public decimal SurfaceTemp { get; set; }
		public int HydroId { get; set; }
		public decimal HydroExt { get; set; }
		public decimal AtmosPress { get; set; }
		public decimal Albedo { get; set; }
		public decimal GreenHouseFactor { get; set; }
		public decimal OrbitalPeriodHours { get; set; }
		public decimal RotationalPeriodHours { get; set; }

		public PlanetBody()
		{
			Id = Guid.NewGuid();
		}

		public PlanetBody(Guid id)
		{
			Id = id;
		}
	}
}
