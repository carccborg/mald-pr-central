using Content.Server.Atmos.EntitySystems;
using Content.Server.Radiation.Systems;
using Content.Shared.Atmos;
using Robust.Shared.Map;
using Robust.Shared.GameObjects;

namespace Content.Server.Atmos;

/// <summary>
/// Applies radiation to nearby entities when Tritium exists in nearby active atmos tiles.
/// <summary>

[UpdateAfter(typeof(AtmosphereSystem))]
public sealed class TritiumRadiationSystem : EntitySystem
{
	// TODO: implement

	// for each grid,
		// for each active tile on that grid,
			// if the tile has no atmosphere, skip this tile
			// get the number of moles of tritium on that tile
			// if the number of moles is below a constant, skip this tile
			// cluster tiles together and sum their sources together
			// create a virtual radiation source every 1-2s using the clustered tiles' summed tritium mols
}